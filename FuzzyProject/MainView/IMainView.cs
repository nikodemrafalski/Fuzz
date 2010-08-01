using System.Collections.Generic;
using System.Drawing;

namespace FuzzyProject
{
    public interface IMainView
    {
        void DisplaySourceImage(Image image);
        void UpdateAlgorithmsList(IEnumerable<string> algoritmsNames);
    }
}