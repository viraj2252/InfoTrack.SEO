using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InfoTrack.SEO.Core.Enums
{
    public enum SearchEngine
    {
        [EnumMember(Value = "Google")]
        Google,
        [EnumMember(Value = "Bing")]
        Bing
    }
}
