using System;

class Lesson1 {
    //IP Calculator
    static int Main(string[] args) {
        if (args.Length == 1){
            string str = args[0];
            String[] subs = str.Split('.', '\\', '/');
            Int32[] addr = new int[5];
            Int32[] Mask = new int[4];
            Int32[] Net = new int[4];
            Int32[] Br = new int[4];
            Int32[] HostMin = new int[4];
            Int32[] HostMax = new int[4];
            Int32[] WildCard = new int[4];
            int  n = subs.Length;
                for (int i=0;i<n;i++){
                     addr[i] = Int32.Parse(subs[i]);
                 }
            int Netmask = addr[4];
             
                for (int i=0;i<4;i++){
                    double oktet = 0; 
                       for(int a = 0;  a<8; a++){
                            Netmask --;
                            if (Netmask>=0){
                                oktet = oktet + Math.Pow(2 , 7-a);
                            }
                        }
                    Mask[i] = Convert.ToInt32(oktet);
                    WildCard[i] = 255-Mask[i];
                    }
                for (int i=0;i<4;i++){
                    Net[i] = addr[i]&Mask[i];
                    Br[i] = addr[i] | WildCard[i];
                    HostMin[i] = Net[i];
                    HostMax[i] = Br[i];
                }
            HostMin[3] = Net[3]+1;
            HostMax[3] = Br[3]-1;
            Console.WriteLine("сеть: [{0}]", string.Join(". ", Net));
            Console.WriteLine("Маска: [{0}]", string.Join(". ", Mask));
            Console.WriteLine("Бродкаст: [{0}]", string.Join(". ", Br));
            Console.WriteLine("Минимальный адрес: [{0}]", string.Join(". ", HostMin));
            Console.WriteLine("Максимальный адрес: [{0}]", string.Join(". ", HostMax));
            return 0;
        }
        else {
            Console.WriteLine("введите адрес  в формате A.B.C.D/E");
            return 1;
        }
    }
    
}