class Calculator {
    constructor(inputDivTextElement, outputDivTextElement) {
      this.inputDivTextElement = inputDivTextElement
      this.outputDivTextElement = outputDivTextElement
      this.clear()
    }

    clear() {
      /* Clears all values */
      this.outputDiv = ''
      this.inputDiv = ''
      this.operation = undefined
    }

    appendNumber(number) {
      /* Chooses number/s */
      this.outputDiv = this.outputDiv.toString() + number.toString()
    }

    chooseOperand(operation) {
      /* Chooses operation */
      this.operation = operation
      this.inputDiv = this.outputDiv
      this.outputDiv = ''
    }

    calculate() {
          /* Calculates the equation */
      let computation
      const prev = parseFloat(this.inputDiv)
      const current = parseFloat(this.outputDiv)
      if (isNaN(prev) || isNaN(current)) return
      switch (this.operation) {
        case '+':
          computation = prev + current
          break
        case '-':
          computation = prev - current
          break
        case '*':
          computation = prev * current
          break
        case '÷':
          computation = prev / current
          break
        default:
          return
      }
      this.outputDiv = computation
      this.operation = undefined
      this.inputDiv = ''
    }

    getDisplayNumber(number) {
          /* Gets the display number/s */
      const stringNumber = number.toString()
      const integerDigits = parseFloat(stringNumber.split('.')[0])
      const decimalDigits = stringNumber.split('.')[1]
      let integerDisplay
      if (isNaN(integerDigits)) {
        integerDisplay = ''
      } else {
        integerDisplay = integerDigits.toLocaleString('en', { maximumFractionDigits: 0 })
      }
      if (decimalDigits != null) {
        return `${integerDisplay}.${decimalDigits}`
      } else {
        return integerDisplay
      }
    }

    showResult() {
          /* Shows the result */
      this.outputDivTextElement.innerText =
        this.getDisplayNumber(this.outputDiv)
      if (this.operation != null) {
        this.inputDivTextElement.innerText =
          `${this.getDisplayNumber(this.inputDiv)} ${this.operation}`
      } else {
        this.inputDivTextElement.innerText = ''
      }
    }
  }


  /* Connects the data attributes from the HTML doc */
  const numberButtons = document.querySelectorAll('[data-numbers]')
  const operandButtons = document.querySelectorAll('[data-operands]')
  const equalButton = document.querySelector('[data-equalSign]')
  const clearButton = document.querySelector('[data-clearData]')
  const inputDivTextElement = document.querySelector('[data-operation]')
  const outputDivTextElement = document.querySelector('[data-result]')

  /* Assign const to class */
  const calculator = new Calculator(inputDivTextElement, outputDivTextElement)

    /* Action when clicking buttons */
  numberButtons.forEach(button => {
    button.addEventListener('click', () => {
      calculator.appendNumber(button.innerText)
      calculator.showResult()
    })
  })
  
  operandButtons.forEach(button => {
    button.addEventListener('click', () => {
      calculator.chooseOperand(button.innerText)
      calculator.showResult()
    })
  })
  
  equalButton.addEventListener('click', button => {
    calculator.calculate()
    calculator.showResult()
  })
  
  clearButton.addEventListener('click', button => {
    calculator.clear()
    calculator.showResult()
  })