using System;
using System.Drawing;
using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new UtilityForm());
    }
}

class UtilityForm : Form
{
    private TextBox waterValue;
    private TextBox waterTariff;

    private TextBox electricityValue;
    private TextBox electricityTariff;

    private TextBox gasValue;
    private TextBox gasTariff;

    private Label resultLabel;

    public UtilityForm()
    {
        Text = "Utility Calculator";
        Size = new Size(500, 450);
        StartPosition = FormStartPosition.CenterScreen;

        Label waterLabel = new Label();
        waterLabel.Text = "Water:";
        waterLabel.Location = new Point(30, 30);
        waterLabel.AutoSize = true;

        waterValue = new TextBox();
        waterValue.Location = new Point(150, 27);
        waterValue.Width = 120;

        waterTariff = new TextBox();
        waterTariff.Location = new Point(290, 27);
        waterTariff.Width = 120;

        Label electricityLabel = new Label();
        electricityLabel.Text = "Electricity:";
        electricityLabel.Location = new Point(30, 80);
        electricityLabel.AutoSize = true;

        electricityValue = new TextBox();
        electricityValue.Location = new Point(150, 77);
        electricityValue.Width = 120;

        electricityTariff = new TextBox();
        electricityTariff.Location = new Point(290, 77);
        electricityTariff.Width = 120;

        Label gasLabel = new Label();
        gasLabel.Text = "Gas:";
        gasLabel.Location = new Point(30, 130);
        gasLabel.AutoSize = true;

        gasValue = new TextBox();
        gasValue.Location = new Point(150, 127);
        gasValue.Width = 120;

        gasTariff = new TextBox();
        gasTariff.Location = new Point(290, 127);
        gasTariff.Width = 120;

        Label valueHint = new Label();
        valueHint.Text = "Consumption";
        valueHint.Location = new Point(150, 5);
        valueHint.AutoSize = true;

        Label tariffHint = new Label();
        tariffHint.Text = "Tariff";
        tariffHint.Location = new Point(290, 5);
        tariffHint.AutoSize = true;

        Button calculateButton = new Button();
        calculateButton.Text = "Calculate";
        calculateButton.Location = new Point(170, 180);
        calculateButton.Width = 140;
        calculateButton.Click += CalculateButton_Click;

        resultLabel = new Label();
        resultLabel.Location = new Point(30, 230);
        resultLabel.AutoSize = true;
        resultLabel.Font = new Font("Arial", 11);

        Controls.Add(valueHint);
        Controls.Add(tariffHint);

        Controls.Add(waterLabel);
        Controls.Add(waterValue);
        Controls.Add(waterTariff);

        Controls.Add(electricityLabel);
        Controls.Add(electricityValue);
        Controls.Add(electricityTariff);

        Controls.Add(gasLabel);
        Controls.Add(gasValue);
        Controls.Add(gasTariff);

        Controls.Add(calculateButton);
        Controls.Add(resultLabel);
    }

    private void CalculateButton_Click(object? sender, EventArgs e)
    {
        if (!double.TryParse(waterValue.Text, out double water) ||
            !double.TryParse(waterTariff.Text, out double waterPrice) ||
            !double.TryParse(electricityValue.Text, out double electricity) ||
            !double.TryParse(electricityTariff.Text, out double electricityPrice) ||
            !double.TryParse(gasValue.Text, out double gas) ||
            !double.TryParse(gasTariff.Text, out double gasPrice))
        {
            MessageBox.Show(
                "Please enter valid numbers.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        double waterTotal = water * waterPrice;
        double electricityTotal = electricity * electricityPrice;
        double gasTotal = gas * gasPrice;

        double total = waterTotal + electricityTotal + gasTotal;

        resultLabel.Text =
            $"Water: {waterTotal:F2}\n" +
            $"Electricity: {electricityTotal:F2}\n" +
            $"Gas: {gasTotal:F2}\n\n" +
            $"Total: {total:F2}";
    }
}