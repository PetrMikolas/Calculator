using Calculator.Client.Components;
using FluentAssertions;

namespace Calculator.UnitTests;
internal class CalculatorTests
{
    private CalculatorComponent _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new CalculatorComponent();
    }

    [Test]
    public void GetResultAddition_Success()
    {
        // Arrange
        var number1 = "10";
        var number2 = "10";
        var arithmeticOperation = CalculatorComponent.ArithmeticOperation.Addition;
        var result = "20";

        // Act
        var data = _calculator.Calculate(number1, number2, arithmeticOperation);

        // Assert
        data.Should().NotBeNullOrEmpty();
        data.Should().Be(result);
    }

    [Test]
    public void GetResultSubtraction_Success()
    {
        // Arrange
        var number1 = "20";
        var number2 = "10";
        var arithmeticOperation = CalculatorComponent.ArithmeticOperation.Subtraction;
        var result = "10";

        // Act
        var data = _calculator.Calculate(number1, number2, arithmeticOperation);

        // Assert
        data.Should().NotBeNullOrEmpty();
        data.Should().Be(result);
    }

    [Test]
    public void GetResultSubtractionDecimalNumbers_Success()
    {
        // Arrange
        var number1 = "20,5";
        var number2 = "10,8";
        var arithmeticOperation = CalculatorComponent.ArithmeticOperation.Subtraction;
        var result = "9,7";

        // Act
        var data = _calculator.Calculate(number1, number2, arithmeticOperation);

        // Assert
        data.Should().NotBeNullOrEmpty();
        data.Should().Be(result);
    }

    [Test]
    public void GetResultMultiplication_Success()
    {
        // Arrange
        var number1 = "10";
        var number2 = "10";
        var arithmeticOperation = CalculatorComponent.ArithmeticOperation.Multiplication;
        var result = "100";

        // Act
        var data = _calculator.Calculate(number1, number2, arithmeticOperation);

        // Assert
        data.Should().NotBeNullOrEmpty();
        data.Should().Be(result);
    }

    [Test]
    public void GetResultDivision_Success()
    {
        // Arrange
        var number1 = "20";
        var number2 = "10";
        var arithmeticOperation = CalculatorComponent.ArithmeticOperation.Division;
        var result = "2";

        // Act
        var data = _calculator.Calculate(number1, number2, arithmeticOperation);

        // Assert
        data.Should().NotBeNullOrEmpty();
        data.Should().Be(result);
    }

    [Test]
    public void GetResultDivisionDecimalNumbers_Success()
    {
        // Arrange
        var number1 = "15,5";
        var number2 = "3,1";
        var arithmeticOperation = CalculatorComponent.ArithmeticOperation.Division;
        var result = "5";

        // Act
        var data = _calculator.Calculate(number1, number2, arithmeticOperation);

        // Assert
        data.Should().NotBeNullOrEmpty();
        data.Should().Be(result);
    }

    [Test]
    public void GetResultDivisionDecimalNumbersResultInteger_Success()
    {
        // Arrange
        var number1 = "17,7";
        var number2 = "6,2";
        var arithmeticOperation = CalculatorComponent.ArithmeticOperation.Division;
        var isReusultInteger = true;
        var result = "3";

        // Act
        var data = _calculator.Calculate(number1, number2, arithmeticOperation, isReusultInteger);

        // Assert
        data.Should().NotBeNullOrEmpty();
        data.Should().Be(result);
    }

    [Test]
    public void GetResultDivisionByZero_Success()
    {
        // Arrange
        var number1 = "10";
        var number2 = "0";
        var arithmeticOperation = CalculatorComponent.ArithmeticOperation.Division;
        var result = "Nelze dělit nulou";

        // Act
        var data = _calculator.Calculate(number1, number2, arithmeticOperation);

        // Assert
        data.Should().NotBeNullOrEmpty();
        data.Should().Be(result);
    }

    [Test]
    public void GetResultAdditionNegativeNumberResultInteger_Success()
    {
        // Arrange
        var number1 = "10,6";
        var number2 = "-100";
        var arithmeticOperation = CalculatorComponent.ArithmeticOperation.Addition;
        var isReusultInteger = true;
        var result = "-89";

        // Act
        var data = _calculator.Calculate(number1, number2, arithmeticOperation, isReusultInteger);

        // Assert
        data.Should().NotBeNullOrEmpty();
        data.Should().Be(result);
    }

    [Test]
    public void GetResultMultiplicationNegativeNumbers_Success()
    {
        // Arrange
        var number1 = "-10";
        var number2 = "-10";
        var arithmeticOperation = CalculatorComponent.ArithmeticOperation.Multiplication;
        var result = "100";

        // Act
        var data = _calculator.Calculate(number1, number2, arithmeticOperation);

        // Assert
        data.Should().NotBeNullOrEmpty();
        data.Should().Be(result);
    }

    [Test]
    public void GetResultInputNumbersNull_Success()
    {
        // Arrange		
        var arithmeticOperation = CalculatorComponent.ArithmeticOperation.Multiplication;
        var result = string.Empty;

        // Act
        var data = _calculator.Calculate(null!, null!, arithmeticOperation);

        // Assert
        data.Should().NotBeNull();
        data.Should().Be(result);
    }

    [Test]
    public void GetResultInputNumbersEmptyString_Success()
    {
        // Arrange		
        var arithmeticOperation = CalculatorComponent.ArithmeticOperation.Multiplication;
        var result = string.Empty;

        // Act
        var data = _calculator.Calculate(string.Empty, string.Empty, arithmeticOperation);

        // Assert
        data.Should().NotBeNull();
        data.Should().Be(result);
    }
}