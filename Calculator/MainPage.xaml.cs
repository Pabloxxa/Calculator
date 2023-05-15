namespace Calculator;

public partial class MainPage : ContentPage
{
    int currentState = 1;
    string operationMath;
    double firstNum, secondNum;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnClear(object sender, EventArgs e)
    {
        currentState = 1;
        result.Text = "0";
    }
    void OnPercentage(object sender, EventArgs e)
    {
        double _result = 0;
        _result = (firstNum * secondNum) / 100;
        result.Text = _result.ToString();
    }
    private void OnSquareRoot(object sender, EventArgs e)
    {
        double sqrt = Math.Sqrt(double.Parse(result.Text));
        result.Text = sqrt.ToString();
    }
    private void OnNumberSelection(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string btnPressed = button.Text;
        if (result.Text.Equals("0") || currentState != (currentState * (-1)))
        {
            //result.Text = string.Empty;
            if (currentState == 1)
            {
                result.Text += btnPressed;
            }
            else
            {
                result.Text += btnPressed;
            }
        }

        SetOperandNumbers();
    }

    private void SetOperandNumbers()
    {
        double number;
        if (double.TryParse(result.Text, out number))
        {
            //this.result.Text = number.ToString("N0");
            this.result.Text = number.ToString();
            if (currentState == 1)
            {
                firstNum = number;
            }
            else
            {
                secondNum = number;
            }
        }
    }

    void OnOperatorSelection(object sender, EventArgs e)
    {
        //currentState = -2;
        currentState = currentState * (-1);
        result.Text = string.Empty;

        Button button = (Button)sender;
        string btnPressed = button.Text;
        operationMath = btnPressed;
    }

    void OnCalculate(object sender, EventArgs e)
    {
        double _result = 0;

        switch (operationMath)
        {
            case "/":
                _result = firstNum / secondNum;
                break;
            case "*":
                _result = firstNum * secondNum;
                break;
            case "+":
                _result = firstNum + secondNum;
                break;
            case "-":
                _result = firstNum - secondNum;
                break;
        }

        result.Text = _result.ToString();
        currentState = (currentState * (-1));
        firstNum = _result;
    }
    //private void OnCounterClicked(object sender, EventArgs e)
    //{
    //	count++;

    //	if (count == 1)
    //		CounterBtn.Text = $"Clicked {count} time";
    //	else
    //		CounterBtn.Text = $"Clicked {count} times";

    //	SemanticScreenReader.Announce(CounterBtn.Text);
    //}
    void OnChangeSign(object o, EventArgs e)
    {
        double _result = (-1) * double.Parse(result.Text);
        result.Text = _result.ToString();
    }
    void OnSetDecimalPoint(object o, EventArgs e)
    {
        if (!result.Text.Contains(','))
        {
            result.Text += ',';
        }

    }
}
