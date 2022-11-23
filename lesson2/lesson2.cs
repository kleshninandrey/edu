using System;
using System.Linq;

class FormalNeuronDemo {
	class Neuron {
		public double a {  get;}= 0.02; 	// свойства с модификаторами доступа, 
		public double b {  get;}= -0.4; 	//которые  делают свойства доступными только для чтения в нашем случае
		public double[] w {  get;}= {0, 0, 0, 0};
		public int c {  get;} = 0;


        public Neuron (LData []X) { 
			while (learn(X)) { 
				if (c++ > 10000) break;
			}
		}

        public double calculate(int [] x) {
			double s = b; 
			for (int i = 0; i < w.Length; i++) s += w[i] * x[i];
			return (s > 0) ? 1 : 0;
		}
		
		bool learn(LData [] X) { 
			double[] w_ = new double[w.Length]; 

			Array.Copy(w, w_, w.Length); 

			 int i = 0;
			for( i=0; i< X.Length;i++){
				int y = X[i].y;
				for (int j=0; j < X[i].x.Length; j++) {
					w[j] += a * (X[i].y - calculate(X[i].x)) * X[i].x[j];
				}
			}
			return !Enumerable.SequenceEqual(w_, w);
		}

	}

//Входные данные описаны в виде структуры. позволяет объединить 
// обучающие данные в одну переменную типа LData и обращаться в последствии к полям одной структуры
	 struct LData
	 {	
		public int [] x;
		public int y ;
		
	}

	static int[][] Test = {
		new int [] {0, 0, 0, 0}, 
		new int [] {0, 0, 0, 1}, 
		new int [] {0, 1, 0, 1},
		new int [] {0, 1, 1, 0},
		new int [] {1, 1, 1, 0}, 
		new int [] {1, 1, 1, 1}
	};
// Инициируем массив структур типа LData
	public static int Main() {
		LData [] X = new LData[5];
		X[0].x = new int [] {0, 0, 0, 0}; X[0].y = 0;
		X[1].x = new int [] {0, 0, 0, 1}; X[1].y = 1;
		X[2].x = new int [] {1, 1, 1, 0}; X[2].y = 1;
		X[3].x = new int [] {1, 1, 1, 0}; X[3].y = 0;
		X[4].x = new int [] {1, 1, 1, 1}; X[4].y = 1;

	
		
		Neuron neuron = new Neuron(X); 
		Console.WriteLine("[{0}] {1}", 
			string.Join(", ", neuron.w), 
			neuron.c
			);

		foreach(int[] test in Test) { 
			Console.WriteLine("[{0}] {1} {2}", 
				string.Join(", ", test), 
				test[3],
				neuron.calculate(test)
			);
		}
		 return 0;
	}
}