using System;
using System.Threading.Tasks;

namespace Commons
{
    public static class ArrayExtensions
    {
        public static double[,] ApplyTransform(this double[,] self, Func<double, double> transform)
        {
            int dim1 = self.GetLength(0);
            int dim2 = self.GetLength(1);
            var result = new double[dim1, dim2];

            Parallel.For(0, dim1, i => Parallel.For(0, dim2, j =>
            {
                result[i, j] = transform(self[i, j]);
            }));
            
            return result;
        }

        public static byte[,] NarrowToBytes(this double[,] self)
        {
            int dim1 = self.GetLength(0);
            int dim2 = self.GetLength(1);
            var result = new byte[dim1, dim2];
            for (int i = 0; i < dim1; i++)
            {
                for (int j = 0; j < dim2; j++)
                {
                    result[i, j] = (byte)(self[i, j]);
                }
            }

            return result;
        }

        public static double[,] ApplyTransform(this byte[,] self, Func<byte, double> transform)
        {
            int dim1 = self.GetLength(0);
            int dim2 = self.GetLength(1);
            var result = new double[dim1, dim2];

            Parallel.For(0, dim1, i => Parallel.For(0, dim2, j =>
            {
                result[i, j] = transform(self[i, j]);
            }));

            return result;
        }

        public static byte[,] ApplyTransform(this byte[,] self, Func<byte, byte> transform)
        {
            int dim1 = self.GetLength(0);
            int dim2 = self.GetLength(1);
            var result = new byte[dim1, dim2];

            Parallel.For(0, dim1, i => Parallel.For(0, dim2, j =>
            {
                result[i, j] = transform(self[i, j]);
            }));

            return result;
        }

        public static Tuple<byte, byte> GetMinAndMaxValues(this byte[,] self)
        {
            byte min = byte.MaxValue, max = byte.MinValue;
            int dim1 = self.GetLength(0);
            int dim2 = self.GetLength(1);

            for (int i = 0; i < dim1; i++)
            {
                for (int j = 0; j < dim2; j++)
                {
                    byte current = self[i, j];
                    if (current > max) { max = current; }
                    if (current < min) { min = current; }
                }
            }

            return new Tuple<byte, byte>(min, max);
        }
    }
}