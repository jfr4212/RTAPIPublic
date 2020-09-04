using System.Text.Json;

namespace RTAPI
{
    public class Triangle
    {
        public Vertex V1 { get; set; }

        public Vertex V2 { get; set; }

        public Vertex V3 { get; set; }

        public string Serialize()
        {
            string result = "";

            result = JsonSerializer.Serialize<Triangle>(this);

            return result;
        }

    }
}
