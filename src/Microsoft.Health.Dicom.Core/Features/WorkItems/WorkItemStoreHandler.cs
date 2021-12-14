﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using MediatR;
using Microsoft.Health.Abstractions.Exceptions;
using Microsoft.Health.Core.Features.Security.Authorization;
using Microsoft.Health.Dicom.Core.Exceptions;
using Microsoft.Health.Dicom.Core.Features.Common;
using Microsoft.Health.Dicom.Core.Features.Security;
using Microsoft.Health.Dicom.Core.Features.Store.Entries;
using Microsoft.Health.Dicom.Core.Features.WorkItems;
using Microsoft.Health.Dicom.Core.Messages.WorkItemMessages;

namespace Microsoft.Health.Dicom.Core.Features.Store
{
    public class WorkItemStoreHandler : BaseHandler, IRequestHandler<WorkItemStoreRequest, WorkItemStoreResponse>
    {
        private readonly IDicomInstanceEntryReaderManager _dicomInstanceEntryReaderManager;
        private readonly IWorkItemService _workItemService;

        public WorkItemStoreHandler(
            IAuthorizationService<DataActions> authorizationService,
            IDicomInstanceEntryReaderManager dicomInstanceEntryReaderManager,
            IWorkItemService workItemService)
            : base(authorizationService)
        {
            _dicomInstanceEntryReaderManager = EnsureArg.IsNotNull(dicomInstanceEntryReaderManager, nameof(dicomInstanceEntryReaderManager));
            _workItemService = EnsureArg.IsNotNull(workItemService, nameof(workItemService));
        }

        /// <inheritdoc />
        public async Task<WorkItemStoreResponse> Handle(
            WorkItemStoreRequest request,
            CancellationToken cancellationToken)
        {
            EnsureArg.IsNotNull(request, nameof(request));

            if (await AuthorizationService.CheckAccess(DataActions.Write, cancellationToken) != DataActions.Write)
            {
                throw new UnauthorizedDicomActionException(DataActions.Write);
            }

            // StoreRequestValidator.ValidateRequest(request);

            // Find a reader that can parse the request body.
            IDicomInstanceEntryReader dicomInstanceEntryReader = _dicomInstanceEntryReaderManager.FindReader(request.RequestContentType);

            if (dicomInstanceEntryReader == null)
            {
                throw new UnsupportedMediaTypeException(
                    string.Format(CultureInfo.InvariantCulture, DicomCoreResource.UnsupportedContentType, request.RequestContentType));
            }

            // Read list of entries.
            IReadOnlyList<IDicomInstanceEntry> instanceEntries = await dicomInstanceEntryReader.ReadAsync(
                    request.RequestContentType,
                    request.RequestBody,
                    cancellationToken);

            // Process list of entries.
            return await _workItemService
                .ProcessAsync(// instanceEntries,
                    request.WorkItemInstanceUid, cancellationToken);
        }
    }
}
