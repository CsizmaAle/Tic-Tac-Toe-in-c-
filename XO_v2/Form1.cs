using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace XO_atestat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        int[] b = new int[10];  // vector
        bool x = false;
        bool o = false;
        int ok = 0;
        int wino = 0;
        int winx = 0;
        int j = 1;

        public void Verificare()
        {
            ok = 0;
            int cnt = 0;
            if (b[1] == b[2] && b[2] == b[3] && b[2] == 88) ok = 2;         // 1 2 3 x
            else if (b[1] == b[2] && b[2] == b[3] && b[2] == 79) ok = 3;    // 1 2 3 o
            else if (b[4] == b[5] && b[5] == b[6] && b[5] == 88) ok = 2;    // 4 5 6 x
            else if (b[4] == b[5] && b[5] == b[6] && b[5] == 79) ok = 3;    // 4 5 6 o
            else if (b[7] == b[8] && b[8] == b[9] && b[8] == 88) ok = 2;    // 7 8 9 x
            else if (b[7] == b[8] && b[8] == b[9] && b[9] == 79) ok = 3;    // 7 8 9 o
            else if (b[4] == b[1] && b[1] == b[7] && b[7] == 88) ok = 2;    // 1 4 7 x
            else if (b[4] == b[1] && b[1] == b[7] && b[7] == 79) ok = 3;    // 1 4 7 o
            else if (b[2] == b[5] && b[5] == b[8] && b[8] == 88) ok = 2;    // 2 5 8 x
            else if (b[2] == b[5] && b[5] == b[8] && b[5] == 79) ok = 3;    // 2 5 8 o
            else if (b[3] == b[6] && b[9] == b[6] && b[9] == 88) ok = 2;    // 3 6 9 x
            else if (b[3] == b[6] && b[9] == b[6] && b[9] == 79) ok = 3;    // 3 6 9 o
            else if (b[1] == b[5] && b[9] == b[5] && b[9] == 88) ok = 2;    // 1 5 9 x
            else if (b[1] == b[5] && b[9] == b[5] && b[9] == 79) ok = 3;    // 1 5 9 o
            else if (b[3] == b[5] && b[5] == b[7] && b[7] == 88) ok = 2;    // 3 5 7 x
            else if (b[3] == b[5] && b[7] == b[5] && b[3] == 79) ok = 3;    // 3 5 7 o

            // check if the vector is full
            for (int i = 1; i <= 9; i++)
                if (b[i] != 0) cnt++;

            // end of the game
            if (cnt == 9 && ok == 0)
            {
                ok = 1;
                // we create a mesaje box to inform the players 
                DialogResult result = MessageBox.Show("NOBODY WON! PLAY AGAIN?" + Environment.NewLine +
                    "Score" + Environment.NewLine + "X: " + winx + Environment.NewLine + "0: " + wino,
                    "game over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) { restart(); }
                else
                {
                    this.Close();
                    Meniu meniu = new Meniu();
                    meniu.Show();
                    this.Close();
                }
            }
            else
                if (ok == 2)
            {
                winx++;
                DialogResult result = MessageBox.Show("PLAYER X WINS! PLAY AGAIN?" + Environment.NewLine +
                    "Score" + Environment.NewLine + "X: " + winx + Environment.NewLine + "0: " + wino, "congrats",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) { restart(); }
                else
                {
                    this.Close();
                    Meniu meniu = new Meniu();
                    meniu.Show();
                    this.Close();
                }
            }
            else
                    if (ok == 3)
            {
                wino++;
                DialogResult result = MessageBox.Show("PLAYER 0 WINS! PLAY AGAIN?" + Environment.NewLine + "Score" +
                    Environment.NewLine + "X: " + winx + Environment.NewLine + "0: " + wino, "congrats",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) { restart(); }
                else
                {
                    this.Close();
                    Meniu meniu = new Meniu();
                    meniu.Show();
                    this.Close();
                }
            }
        }

        public void restart()
        {
            for (int i = 1; i <= 9; i++) b[i] = 0;
            disable();
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button12.BackColor = Color.White;
            button13.BackColor = Color.White;
            button14.BackColor = Color.White;
            button6.BackColor = Color.White;
            button9.BackColor = Color.White;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            button1.Text = " ";
            button2.Text = " ";
            button3.Text = " ";
            button4.Text = " ";
            button12.Text = " ";
            button13.Text = " ";
            button14.Text = " ";
            button6.Text = " ";
            button9.Text = " ";
            j = 1;
            label2.Text = winx.ToString();
            label3.Text = wino.ToString();

        }

        private void button1_Click(object sender, EventArgs e) // box 1
        {
            if (x == true)
            {
                button1.Text = "X"; // place X
                b[1] = 88; // note that in box 1 is X
                button1.BackColor = Color.SkyBlue; // change button color
            }

            if (o == true)
            {
                button1.Text = "O"; // place O
                b[1] = 79; // note O 
                button1.BackColor = Color.LightPink; // change button color
            }

            disable();// disable the buttons
            o = false; x = false; // reset selection
            button10.BackColor = Color.White; // reset colors for button 11 and 10
            button11.BackColor = Color.White;
            Verificare(); // check if someone won 
            joc(j++);
        }

        private void button2_Click(object sender, EventArgs e)// box 2
        {
            if (x == true) { button2.Text = "X"; b[2] = 88; button2.BackColor = Color.SkyBlue; }
            if (o == true) { button2.Text = "O"; b[2] = 79; button2.BackColor = Color.LightPink; }
            disable();
            o = false; x = false;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            Verificare();
            joc(j++);
        }

        private void button3_Click(object sender, EventArgs e) // box 3
        {
            if (x == true) { button3.Text = "X"; b[3] = 88; button3.BackColor = Color.SkyBlue; }
            if (o == true) { button3.Text = "O"; b[3] = 79; button3.BackColor = Color.LightPink; }
            disable();
            o = false; x = false;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            Verificare();
            joc(j++);
        }

        private void button4_Click(object sender, EventArgs e) // box 4
        {
            if (x == true) { button4.Text = "X"; b[4] = 88; button4.BackColor = Color.SkyBlue; }
            if (o == true) { button4.Text = "O"; b[4] = 79; button4.BackColor = Color.LightPink; }
            disable();
            o = false; x = false;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            Verificare();
            joc(j++);
        }

        private void button6_Click(object sender, EventArgs e) // box 6
        {
            if (x == true) { button6.Text = "X"; b[6] = 88; button6.BackColor = Color.SkyBlue; }
            if (o == true) { button6.Text = "O"; b[6] = 79; button6.BackColor = Color.LightPink; }
            disable();
            o = false; x = false;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            Verificare();
            joc(j++);
        }

        private void button9_Click(object sender, EventArgs e) // box 9
        {
            if (x == true) { button9.Text = "X"; b[9] = 88; button9.BackColor = Color.SkyBlue; }
            if (o == true) { button9.Text = "O"; b[9] = 79; button9.BackColor = Color.LightPink; }
            disable();
            o = false; x = false;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            Verificare();
            joc(j++);
        }

        private void button12_Click(object sender, EventArgs e) // box 5
        {
            if (x == true) { button12.Text = "X"; b[5] = 88; button12.BackColor = Color.SkyBlue; }
            if (o == true) { button12.Text = "O"; b[5] = 79; button12.BackColor = Color.LightPink; }
            disable();
            o = false; x = false;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            Verificare();
            joc(j++);
        }

        private void button14_Click(object sender, EventArgs e) // box 8
        {
            if (x == true) { button14.Text = "X"; b[8] = 88; button14.BackColor = Color.SkyBlue; }
            if (o == true) { button14.Text = "O"; b[8] = 79; button14.BackColor = Color.LightPink; }
            disable();
            o = false; x = false;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            Verificare();
            joc(j++);
        }

        private void button13_Click(object sender, EventArgs e) // box 7
        {
            if (x == true) { button13.Text = "X"; b[7] = 88; button13.BackColor = Color.SkyBlue; }
            if (o == true) { button13.Text = "O"; b[7] = 79; button13.BackColor = Color.LightPink; }
            disable();
            o = false; x = false;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            Verificare();
            joc(j++);
        }
        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++) b[i] = 0;
            label2.Text = winx.ToString();
            label3.Text = wino.ToString();
            disable(); // disable all buttons
            joc(j++);
        }

        public void joc(int j)
        {
            if (j % 2 == 0)
            {
                o = true;
                x = false;
                button11.BackColor = Color.Blue;
                button10.BackColor = Color.White;
                enable();
            }
            else
            {
                o = false;
                x = true;
                button10.BackColor = Color.Blue;
                button11.BackColor = Color.White;
                enable();
            }
        }

        public void disable() // disables all the buttons
        {
            button1.Enabled = false;
            button12.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button9.Enabled = false;
        }

        public void enable()
        {
            if (b[1] == 0) button1.Enabled = true;
            if (b[2] == 0) button2.Enabled = true;
            if (b[3] == 0) button3.Enabled = true;
            if (b[4] == 0) button4.Enabled = true;
            if (b[5] == 0) button12.Enabled = true;
            if (b[6] == 0) button6.Enabled = true;
            if (b[7] == 0) button13.Enabled = true;
            if (b[8] == 0) button14.Enabled = true;
            if (b[9] == 0) button9.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Meniu meniu = new Meniu();
            meniu.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}