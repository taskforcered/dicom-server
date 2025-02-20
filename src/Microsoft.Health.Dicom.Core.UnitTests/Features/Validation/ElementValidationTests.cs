﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using Dicom;
using Microsoft.Health.Dicom.Core.Exceptions;
using Microsoft.Health.Dicom.Core.Features.Validation;
using Xunit;

namespace Microsoft.Health.Dicom.Core.UnitTests.Features.Validation
{
    public class ElementValidationTests
    {

        [Fact]
        public void GivenSingleValueElement_WhenValidating_ThenShouldPass()
        {
            new ElementValidation().Validate(new DicomIntegerString(DicomTag.DoseReferenceNumber, "012345678912"));
        }

        [Fact]
        public void GivenZeroValueElement_WhenValidating_ThenShouldPass()
        {
            new ElementValidation().Validate(new DicomIntegerString(DicomTag.DoseReferenceNumber, new string[0]));

        }
        [Fact]
        public void GivenMultiValueElement_WhenValidating_ThenShouldThrow()
        {
            var ex = Assert.Throws<ElementValidationException>(() =>
                 new ElementValidation().Validate(new DicomIntegerString(DicomTag.DoseReferenceNumber, "012345678912", "012345678913")));
            Assert.Equal(ValidationErrorCode.MultiValues, ex.ErrorCode);
        }

    }
}
