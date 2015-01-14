using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PixIt_0._3 {

    static class BitmapPixelPointer {

        public class Pointer : IDisposable {
            private object ClassReference;
            private string VarialbleName;

            private Bitmap DefaultBitmap;
            private Color color;

            private int x;
            private int y;
            private byte CurrentOffset = 0;
            private bool OffsetIncrease = true;

            public Pointer(object _ClassReference, string _VarialbleName, int _x, int _y, Color _Color) {
                BitmapPixelPointer.AddPixelPointer(this);
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

            public void Dispose() {
                BitmapPixelPointer.RemovePixelPointer(this);
                GC.SuppressFinalize(this);
            }
        }

        private static List<Pointer> PixelPointerList = new List<Pointer>();
        private static Thread ThreadTicker = new Thread(ThreadDrawTick);

        static BitmapPixelPointer() {
            ThreadTicker.Start();
            Program.Form.FormClosing += Form_FormClosing;  
        }

        private static void Form_FormClosing(object sender, FormClosingEventArgs e) {
            ThreadTicker.Abort();
        }

        public static void SetDefaultBitmap(Bitmap _Bitmap) {
            new Bitmap(_Bitmap);
        }

        public static void AddPixelPointer(Pointer _instance) {
            PixelPointerList.Add(_instance);
        }

        public static void RemovePixelPointer(Pointer _instance) {
            PixelPointerList.Remove(_instance);
        }

        public static void DisposeAll() {
            for(int i = 0; i < PixelPointerList.Count; i++) {
                PixelPointerList[i].Dispose();
            }
            PixelPointerList.Clear();
        }

        private static void ThreadDrawTick() {
            while(true) {
                try {
                    foreach(Pointer bpp in PixelPointerList) {
                        bpp.SetDefaultBitmap();
                    }
                    foreach(Pointer bpp in PixelPointerList) {
                        bpp.DrawPointer();
                    }
                } catch { }

                Program.Form.ReloadPictureBox();
                Thread.Sleep(150);
            }
        }

    }

}
