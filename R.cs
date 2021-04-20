using System;
namespace LiteralObfuscator
{
    public partial class R
    {
        public static string SuperSecurePassword
        {
            get
            {
                var buffer=new byte[8];
                buffer[0]=112;
                buffer[1]=97;
                buffer[2]=115;
                buffer[3]=115;
                buffer[4]=119;
                buffer[5]=111;
                buffer[6]=114;
                buffer[7]=100;
                return System.Text.Encoding.UTF8.GetString(buffer);
            }
        }
        public static float MySalary
        {
            get
            {
                var buffer=new byte[4];
                buffer[0]=219;
                buffer[1]=15;
                buffer[2]=73;
                buffer[3]=64;
                return BitConverter.ToSingle(buffer,0);
            }
        }
        public static float AgeOfYildizTilbe
        {
            get
            {
                var buffer=new byte[4];
                buffer[0]=54;
                buffer[1]=0;
                buffer[2]=0;
                buffer[3]=0;
                return BitConverter.ToInt32(buffer,0);
            }
        }
    }
}
