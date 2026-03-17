using System.Drawing;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using Flit;
using Capture = FlaUI.Core.Capturing.Capture;

namespace Demo {
   #region Class util------------------------------------------------------------------------------
  
  public class Util {
      #region Method-------------------------------------------------
      public static void imageCompare (string actualImagePath,string expectedImagePath) {
         var actualCapture = Capture.Rectangle (new Rectangle (7, 44, 1176, 117));
         actualCapture.ToFile (actualImagePath);
         var expectedCapture = Capture.Rectangle (new Rectangle (7, 44, 1176, 117));
         expectedCapture.ToFile (expectedImagePath);
         Thread.Sleep (300);
         Bitmap actual = new Bitmap (actualImagePath);
         Bitmap expected = new Bitmap (expectedImagePath);
         var iImagesSame = true;
         for (int y = 0; y < expected.Height; y++) {
            for (int x = 0; x < expected.Width; x++) {
               if (expected.GetPixel (x, y) != actual.GetPixel (x, y)) {
                  iImagesSame = false;
                  break;
               }
            }
         }
         if (iImagesSame) Console.WriteLine( "Values screenshot match");
         else Assert.Fail ("Values screenshot mismatch");
      }

      public static void workoffset (string elename, String name, string autoid, string stbtn) {
         var uia3 = new UIA3Automation ();
         var win = uia3.GetDesktop ().FindFirstDescendant (x => x.ByAutomationId ("HomePage")).AsWindow (); // Home window
         string[] work = [elename, name];
         string[] id = [autoid, stbtn];
         foreach (var stb in work)
            win.FindFirstDescendant (x => x.ByName (stb))!.Click ();
         Thread.Sleep (500);
         foreach (var verify in id) {
            win.FindFirstDescendant (x => x.ByAutomationId (verify))!.Click ();
            Thread.Sleep (500);
         }
      }

      public static void manual (string eleName, String workOffName, string value1,
      string value2, string automId, string okBtn) {
         var uia3 = new UIA3Automation ();
         var win = uia3.GetDesktop ().FindFirstDescendant (x => x.ByAutomationId ("HomePage")).AsWindow (); // Home window
         string[] name = [eleName, workOffName];
         string[] values = [value1, value2,];
         string[] Ids = [ automId, okBtn];
         foreach (var manual in name)
           win.FindFirstDescendant (x => x.ByName (manual)).Click();
         Thread.Sleep (500);
         for (int i = 0; i < values.Length; i++) {
            win.FindFirstDescendant (x => x.ByAutomationId (values[i]))!.Click ();
            Keyboard.Type ("500");
         }
            foreach (var verified in Ids)
               win.FindFirstDescendant (x => x.ByAutomationId (verified))!.Click ();
               Thread.Sleep (500);
         
      }

      public static void byName (string eleName,string wrkOff) {
         var uia3 = new UIA3Automation ();
         var win = uia3.GetDesktop ().FindFirstDescendant (x => x.ByAutomationId ("HomePage")).AsWindow (); // Home window
         string[] name = [eleName, wrkOff];
         foreach(var byname in name)
          win.FindFirstDescendant (x => x.ByName (byname))!.Click ();
         Thread.Sleep (500);
      }
      #endregion

   }
   #endregion
}
