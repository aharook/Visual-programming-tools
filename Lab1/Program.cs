using System;
using System.Drawing;
using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new CalculatorForm());
    }
}

class CalculatorForm : Form
{
    private TextBox number1;
    private TextBox number2;
    private TextBox number3;

    private Label resultLabel;

    public CalculatorForm()
    {
        Text = "Calculator";
        Size = new Size(400, 350);
        StartPosition = FormStartPosition.CenterScreen;

        Label label1 = new Label();
        label1.Text = "First number:";
        label1.Location = new Point(30, 30);
        label1.AutoSize = true;

        number1 = new TextBox();
        number1.Location = new Point(150, 27);
        number1.Width = 180;

        Label label2 = new Label();
        label2.Text = "Second number:";
        label2.Location = new Point(30, 70);
        label2.AutoSize = true;

        number2 = new TextBox();
        number2.Location = new Point(150, 67);
        number2.Width = 180;

        Label label3 = new Label();
        label3.Text = "Third number:";
        label3.Location = new Point(30, 110);
        label3.AutoSize = true;

        number3 = new TextBox();
        number3.Location = new Point(150, 107);
        number3.Width = 180;

        Button calculateButton = new Button();
        calculateButton.Text = "Calculate";
        calculateButton.Location = new Point(130, 150);
        calculateButton.Width = 140;
        calculateButton.Click += CalculateButton_Click;

        resultLabel = new Label();
        resultLabel.Location = new Point(30, 200);
        resultLabel.AutoSize = true;
        resultLabel.Font = new Font("Arial", 11);

        Controls.Add(label1);
        Controls.Add(number1);
        Controls.Add(label2);
        Controls.Add(number2);
        Controls.Add(label3);
        Controls.Add(number3);
        Controls.Add(calculateButton);
        Controls.Add(resultLabel);
    }

    private void CalculateButton_Click(object? sender, EventArgs e)
    {
        if (!double.TryParse(number1.Text, out double a) 
            !double.TryParse(number2.Text, out double b) 
            !double.TryParse(number3.Text, out double c))
        {
            MessageBox.Show(
                "Please enter valid numbers.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        double sum = a + b + c;
        double difference = a - b - c;
        double product = a * b * c;

        resultLabel.Text =
            $"Sum: {sum}\n" +
            $"Difference: {difference}\n" +
            $"Product: {product}";
    }
}