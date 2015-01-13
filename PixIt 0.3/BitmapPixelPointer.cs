using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PixIt_0._3 {

    static class BitmapPixelPointerControler {

        private static List<BitmapPixelPointer> PixelPointerList = new List<BitmapPixelPointer>();
        private static Thread ThreadTicker = new Thread(ThreadDrawTick);

        static BitmapPixelPointerControler() {
            ThreadTicker.Start();
            Program.Form.FormClosing += Form_FormClosing;  
        }

        private static void Form_FormClosing(object sender, FormClosingEventArgs e) {
            ThreadTicker.Abort();
        }

        public static void SetDefaultBitmap(Bitmap _Bitmap) {
            new Bitmap(_Bitmap);
        }

        public static void AddPixelPointer(BitmapPixelPointer _instance) {
            PixelPointerList.Add(_instance);
        }

        public static void DisposeAll() {
            PixelPointerList.Clear();
        }

        private static void ThreadDrawTick() {
            while(true) {
                try {
                    foreach(BitmapPixelPointer bpp in PixelPointerList) {
                        bpp.SetDefaultBitmap();
                    }
                    foreach(BitmapPixelPointer bpp in PixelPointerList) {
                        bpp.DrawPointer();
                    }
                } catch { }

                Program.Form.ReloadPictureBox();
                Thread.Sleep(150);
            }
        }

    }

    class BitmapPixelPointer {
        private object ClassReference;
        private string VarialbleName;

        private Bitmap DefaultBitmap;
        private Color color;

        private int x;
        private int y;
        private byte CurrentOffset = 0;
        private bool OffsetIncrease = true;

        public BitmapPixelPointer(object _ClassReference, string _VarialbleName, int _x, int _y, Color _Color) {
            BitmapPixelPointerControler.AddPixelPointer(this);
            ClassReference = _ClassReference;
            VarialbleName = _VarialbleName;
            color = _Color;

            DefaultBitmap = new Bitmap(GetBitmap());

            x = _x;
            y = _y;
        }

        private Bitmap DrawPixelPointer(Bitmap _bitmap, int _x, int _y, Color _color, byte _offset) {
            _bitmap.SetPixel(_x, _y, _color);

            try {
                for(int move = 0; move < 4; move++) {
                    _bitmap.SetPixel(_x - 5 - move - _offset, _y + 1 + move, color);
                    _bitmap.SetPixel(_x - 5 - move - _offset, _y + move, color);
                    _bitmap.SetPixel(_x - 5 - move - _offset, _y - move, color);
                    _bitmap.SetPixel(_x - 5 - move - _offset, _y - 1 - move, color);
                }
            } catch { }

            try {
                for(int move = 0; move < 4; move++) {
                    _bitmap.SetPixel(_x + 5 + move + _offset, _y + 1 + move, color);
                    _bitmap.SetPixel(_x + 5 + move + _offset, _y + move, color);
                    _bitmap.SetPixel(_x + 5 + move + _offset, _y - move, color);
                    _bitmap.SetPixel(_x + 5 + move + _offset, _y - 1 - move, color);
                }
            } catch { }
            
            try {
                for(int move = 0; move < 4; move++) {
                    _bitmap.SetPixel(_x + 1 + move, _y - 5 - move - _offset, color);
                    _bitmap.SetPixel(_x + move, _y - 5 - move - _offset, color);
                    _bitmap.SetPixel(_x - move, _y - 5 - move - _offset, color);
                    _bitmap.SetPixel(_x - 1 - move, _y - 5 - move - _offset, color);
                }
            } catch { }

             try {
                for(int move = 0; move < 4; move++) {
                    _bitmap.SetPixel(_x + 1 + move, _y + 5 + move + _offset, color);
                    _bitmap.SetPixel(_x + move, _y + 5 + move + _offset, color);
                    _bitmap.SetPixel(_x - move, _y + 5 + move + _offset, color);
                    _bitmap.SetPixel(_x - 1 - move, _y + 5 + move + _offset, color);
                }
             } catch { }

            return _bitmap;
        }

        public void DrawPointer() {
            Program.Form.Invoke((MethodInvoker)delegate {
                DrawPixelPointer(GetBitmap(), x, y, Color.Orange, CurrentOffset);
            });

            UpdateCurrentOffset();
        }

        private void UpdateCurrentOffset() {
            if(OffsetIncrease) {
                if(CurrentOffset < 5) {
                    CurrentOffset++;
                } else {
                    OffsetIncrease = false;
                }
            } else {
                if(CurrentOffset > 0) {
                    CurrentOffset--;
                } else {
                    OffsetIncrease = true;
                }
            }
        }

        public void SetDefaultBitmap() {
            if(DefaultBitmap != null) {
                SetBitmap(new Bitmap(DefaultBitmap));
            }
        }

        private Bitmap GetBitmap() {
            return (Bitmap)ClassReference.GetType().GetField(VarialbleName).GetValue(this);
        }

        private void SetBitmap(Bitmap _Bitmap) {
            ClassReference.GetType().GetField(VarialbleName).SetValue(this, _Bitmap);
        }

    }
}
