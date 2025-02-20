﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Health.Dicom.Core.Features.Partition
{
    public interface IPartitionStore
    {
        Task<PartitionEntry> AddPartitionAsync(string partitionName, CancellationToken cancellationToken = default);

        Task<IEnumerable<PartitionEntry>> GetPartitionsAsync(CancellationToken cancellationToken = default);

        Task<PartitionEntry> GetPartitionAsync(string partitionName, CancellationToken cancellationToken = default);
    }
}
