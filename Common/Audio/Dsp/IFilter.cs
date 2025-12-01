using System.Text.Json.Serialization;

namespace ORBIT.ComLink.Common.Audio.Dsp
{
    internal interface IFilter
    {
        float Transform(float input);
    }
}
