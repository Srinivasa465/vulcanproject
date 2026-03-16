using System.Drawing;
using Flit;
using Capture = FlaUI.Core.Capturing.Capture;

namespace Demo {
   #region Class util------------------------------------------------------------------------------
   #endregion
  public class Util {
      #region Method-------------------------------------------------
      public static void imageCompare(string actualImagePath) {
         var expectedCapture = Capture.Rectangle (new Rectangle (7, 44, 1176, 117));
         expectedCapture.ToFile (@"C:\Work\Temp\s11.expected.png");
         Thread.Sleep (300);
         Bitmap actual = new Bitmap (actualImagePath);
         Bitmap expected = new Bitmap (@"C:\Work\Temp\s11.expected.png");
         var iImagesSame = true;
         for (int y = 0; y < expected.Height; y++) {
            for (int x = 0; x < expected.Width; x++) {
               if (expected.GetPixel (x, y) != actual.GetPixel (x, y)) {
                  iImagesSame = false;
                  break;
               }
            }
         }
         if (iImagesSame) Assert.True(iImagesSame,"Values screenshot match");
         else Assert.Fail("Values screenshot mismatch");
      #endregion
      }
   }
}
