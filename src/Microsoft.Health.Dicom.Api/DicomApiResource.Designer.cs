﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Health.Dicom.Api
{


    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class DicomApiResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DicomApiResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Health.Dicom.Api.DicomApiResource", typeof(DicomApiResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The maximum length of a custom audit header value is {0}. The supplied custom audit header &apos;{1}&apos; has length of {2}..
        /// </summary>
        internal static string CustomAuditHeaderTooLarge {
            get {
                return ResourceManager.GetString("CustomAuditHeaderTooLarge", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid QIDO-RS query. Duplicate AttributeId &apos;{0}&apos;. Each attribute is only allowed to be specified once..
        /// </summary>
        internal static string DuplicateAttributeId {
            get {
                return ResourceManager.GetString("DuplicateAttributeId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot specify parameter more than once..
        /// </summary>
        internal static string DuplicateParameter {
            get {
                return ResourceManager.GetString("DuplicateParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The server encountered an internal error. Please retry the request. If the issue persists, please contact support..
        /// </summary>
        internal static string InternalServerError {
            get {
                return ResourceManager.GetString("InternalServerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value is not valid. It need to be one of &quot;{0}&quot;..
        /// </summary>
        internal static string InvalidEnumValue {
            get {
                return ResourceManager.GetString("InvalidEnumValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There was an error reading the multipart request..
        /// </summary>
        internal static string InvalidMultipartBodyPart {
            get {
                return ResourceManager.GetString("InvalidMultipartBodyPart", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The content type &apos;{0}&apos; is either not multipart or is missing boundary..
        /// </summary>
        internal static string InvalidMultipartContentType {
            get {
                return ResourceManager.GetString("InvalidMultipartContentType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to parse value &apos;{0}&apos; as {1}..
        /// </summary>
        internal static string InvalidParse {
            get {
                return ResourceManager.GetString("InvalidParse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field &apos;{0}&apos; in request body is invalid: {1}.
        /// </summary>
        internal static string InvalidRequestBody {
            get {
                return ResourceManager.GetString("InvalidRequestBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The audit information is missing for Controller: {0} and Action: {1}. This usually means the action is not marked with appropriate attribute..
        /// </summary>
        internal static string MissingAuditInformation {
            get {
                return ResourceManager.GetString("MissingAuditInformation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The start parameter in multipart/related request is not supported..
        /// </summary>
        internal static string StartParameterIsNotSupported {
            get {
                return ResourceManager.GetString("StartParameterIsNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The maximum number of custom audit headers allowed is {0}. The number of custom audit headers supplied is {1}..
        /// </summary>
        internal static string TooManyCustomAuditHeaders {
            get {
                return ResourceManager.GetString("TooManyCustomAuditHeaders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified content type &apos;{0}&apos; is not supported..
        /// </summary>
        internal static string UnsupportedContentType {
            get {
                return ResourceManager.GetString("UnsupportedContentType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field is not supported: &quot;{0}&quot;..
        /// </summary>
        internal static string UnsupportedField {
            get {
                return ResourceManager.GetString("UnsupportedField", resourceCulture);
            }
        }
    }
}
