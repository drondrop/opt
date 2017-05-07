using opt_wfa.Data_Types;
using opt_wfa.Factory;
using opt_wfa.Methods.Gen;
using System;
using System.Windows.Forms;

namespace opt_wfa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Fill_cBoxs(); 
        }
        private void Fill_cBoxs()
        {
           
            cBoxFunc.Items.Clear();
            object[] list =
            {
                new ComboBoxItem<string>("10 :  x1^2 + 3 * x2^2 + 2 * x1 * x2"               ,"f10"),//FuncFactory.create(FuncFactory.Functions.F10) ),
                new ComboBoxItem<string>("11 : 100*(x2 – x1^2)^2 + (1 – x1)^2"               ,"f11"),//FuncFactory.create(FuncFactory.Functions.F11) ),
                new ComboBoxItem<string>("19 : 100*(x2 – x1^2)^2 + (1 – x1)^2"               ,"f19"),//FuncFactory.create(FuncFactory.Functions.F19) ),
                 new ComboBoxItem<string>("20 : "               ,"f20"),//FuncFactory.create(FuncFactory.Functions.F19) ),
                  new ComboBoxItem<string>("21 : 2"               ,"f21"),//FuncFactory.create(FuncFactory.Functions.F19) ),
                   new ComboBoxItem<string>("22 : 2"               ,"f22"),//FuncFactory.create(FuncFactory.Functions.F19) ),
                new ComboBoxItem<string>("23 : (x2 – x1^2)^2 + (1 – x1)^2"                   ,"f23"),//FuncFactory.create(FuncFactory.Functions.F23) ),
                 new ComboBoxItem<string>("24 : "                   ,"f24"),//FuncFactory.create(FuncFactory.Functions.F23) ),
                
                new ComboBoxItem<string>("25 : 3*(x1 – 4)^2 + 5*(x2 + 3)^2 + 7*(2*x3 + 1)^2" ,"f25"),//FuncFactory.create(FuncFactory.Functions.F25) ),
                new ComboBoxItem<string>("26 : x1^3 + x2^2 – 3*x1 – 2*x^2 + 2"               ,"f26"),//FuncFactory.create(FuncFactory.Functions.F26) ),
                new ComboBoxItem<string>("27 : –12*x2 + 4*x1^2 + 4*x2^2 – 4*x1*x2"           ,"f27"),//FuncFactory.create(FuncFactory.Functions.F27) ),
                new ComboBoxItem<string>("29 : (x1*x2*x3 – 1)^2 + 5*[x3*(x1 + x2) – 2]^2 + 2*(x1 + x2 + x3 – 3)^2","f29")// FuncFactory.create(FuncFactory.Functions.F29))
                //new ComboBoxItem<iFunc>("GC-Haus", 5),
                //new ComboBoxItem<iFunc>("Ingenieur-/Planungsbüro", 9),
                //new ComboBoxItem<iFunc>("Wowi", 17),
                //new ComboBoxItem<iFunc>("Endverbraucher", 19)
            };

            cBoxFunc.Items.AddRange(list);
            cBoxFunc.SelectedIndex = 0;


            cBoxMethod.Items.Clear();
            object[] list1 =
            {
                new ComboBoxItem<string>("Huk Jivs", "huka_jivs") ,
                new ComboBoxItem<string>("Pauwell", "Pauwell") ,
                new ComboBoxItem<string>("Rozenbrok", "Rozenbrok") 
            };

            cBoxMethod.Items.AddRange(list1);
            cBoxMethod.SelectedIndex = 0;
        }

        private void button_run_Click(object sender, EventArgs e)
        {
            //clearLof();
            //  var funcFactory = new FuncFactory();
            int k = 0;
            // var methodFactory = new MethodFactory();
            Vector X0 = null;
            if (tabControl1.SelectedIndex != 0)
            {
                var GEN = new GenCore(new opt_wfa.Functions.Test.f11());
                X0 = GEN.Run();
            }
            else
            {
                ////////////////
                var funcType = ((ComboBoxItem<string>)(cBoxFunc.SelectedItem)).Value;
                var methodType = ((ComboBoxItem<string>)(cBoxMethod.SelectedItem)).Value;


                //Vector X0 = func.X_0; //getArg(func.arguments);
                var core = new Core(methodType, funcType, new calculateParams()
                {
                    eps = getEps(),
                    max = getIterMax(),
                    maxComboLine1Count = 50,
                    maxComboLine2Count = 10
                });
                k = core.Calculate(ref X0);
               // method.Method(ref X0, new Core(func, getEps(), getIterMax()));
            }
            ////////////////
           
            print("x* = " + X0.ToString() + "K = " + k + "\n");

        }
        private Vector getArg(int count)
        {
            var outArg = new Vector(count);
            outArg[0] = -5;
            outArg[1] = 4;
            outArg[2] = 2;
            return outArg;
        }
        private double getEps()
        {
            double eps;
            if (double.TryParse(textBox_eps.Text, out eps))
                return eps;
            else
                return 0.0000001;
        }
        private int getIterMax()
        {
            return (int)numericUpDown_iterMax.Value;
        }
        private void print(string output)
        {
            textBox_out.AppendText(output);
        }
        private void clearLof()
        {
            textBox_out.Clear();
        }
    }
}
