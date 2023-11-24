using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YılanOyunu
{
    internal class yılan
    {
        yılanParcaları[] yılanParca;
        int yılanBuyuklugu;
        yon yonumuz;

        public yılan()
        {
            yılanParca = new yılanParcaları[3];
            yılanBuyuklugu = 3;
            yılanParca[0] = new yılanParcaları(150, 150);
            yılanParca[1] = new yılanParcaları(160, 150);
            yılanParca[2] = new yılanParcaları(170, 150);
        }

        public void İlerle(yon yon)
        {
            yonumuz = yon;

            if (yon != null)
            {
                for (int i = yılanParca.Length-1; i > 0; i--)
                {
                    yılanParca[i] = new yılanParcaları(yılanParca[i - 1].x_, yılanParca[i - 1].y_);
                }
                yılanParca[0] = new yılanParcaları(yılanParca[0].x_ + yon._x , yılanParca[0].y_ + yon._y);
            }
        }

        public void Buyu()
        {
            Array.Resize(ref yılanParca, yılanParca.Length+1);
            yılanParca[yılanParca.Length - 1] = new yılanParcaları(yılanParca[yılanParca.Length - 2].x_ - yonumuz._x, yılanParca[yılanParca.Length - 2].y_ - yonumuz._y);
            yılanBuyuklugu++;
        }

        public Point GetPos(int number)
        {
            return new Point(yılanParca[number].x_, yılanParca[number].y_);
        }

    }

    class yılanParcaları
    {
        public int x_;
        public int y_;
        public readonly int size_x;
        public readonly int size_y;

        public yılanParcaları(int x, int y)
        {
            x_ = x;
            y_ = y;
            size_x = 10;
            size_y = 10;
        }
    }

    class yon
    {
        public readonly int _x;
        public readonly int _y;

        public yon(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
    
    
 }


