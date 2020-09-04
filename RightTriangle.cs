using System;
using System.Text.Json;

namespace RTAPI
{
    public class RightTriangle
    {

        public Triangle CoordinateToRightTriangle(string arg)
        {
            Triangle result = new Triangle { };
            int Aint = (int)('A');

            result.V1 = new Vertex();
            result.V2 = new Vertex();
            result.V3 = new Vertex();

            try
            {

                int row = 0;
                string argUpper = arg.ToUpper();
                string rowChar = argUpper.Substring(0, 1);
                row = (int)(rowChar[0]) - Aint + 1;

                int col = 0;
                bool didParse = Int32.TryParse(argUpper.Substring(1), out col);

                if (ValidBoundaries(col, row))
                {
                    if (didParse)
                    {

                        if (col % 2 == 0)
                        {
                            // even column
                            result.V1.X = col / 2 * 10;
                            result.V1.Y = (row - 1) * 10;

                            result.V2.X = result.V1.X - 10;
                            result.V2.Y = result.V1.Y;

                            result.V3.X = result.V1.X;
                            result.V3.Y = result.V1.Y + 10;
                        }
                        else
                        {
                            // odd column
                            result.V1.X = col / 2 * 10;
                            result.V1.Y = row * 10;

                            result.V2.X = result.V1.X;
                            result.V2.Y = result.V1.Y - 10;

                            result.V3.X = result.V1.X + 10;
                            result.V3.Y = result.V1.Y;
                        }
                    }
                }
            }

            catch
            {
                // returns the empty triangle
            }

            return result;
        }

        public string RightTriangleToCoordinate(string jsonTriangle)
        {
            string result = "Invalid Boundary";
            int Aint = (int)('A');

            try
            {
                Triangle tri = JsonSerializer.Deserialize<Triangle>(jsonTriangle);

                int V1x = tri.V1.X;
                int V2x = tri.V2.X;
                int col = 0;
                int row = 0;

                if (V1x > V2x)
                {
                    // even column
                    col = V1x / 10 * 2;
                    row = tri.V1.Y / 10;
                }
                else
                {
                    // odd column
                    col = V1x / 10 * 2 + 1;
                    row = tri.V1.Y / 10 - 1;
                }

                if (ValidBoundaries(col, row))
                {
                    result = Convert.ToChar(Aint + row).ToString() + col.ToString();
                }

            }
            catch
            {
                result = "Invalid json triangle definition";
            }

            return result;
        }

        private bool ValidBoundaries(int col, int row)
        {
            bool result = false;

            if (col >= 1 && col <= 12)
            {
                if (row >= 0 && row <= 6)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
