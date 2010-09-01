using System.Drawing;
using AForge.Imaging;

namespace Logic.Subjective
{
    public interface IMeasure
    {
        double Evaluate(Bitmap image);
    }
}