class Calculator {
    constructor(previousOperationTextElement, currentOperationTextElement) {
        this.previousOperationTextElement = previousOperationTextElement;
        this.currentOperationTextElement = currentOperationTextElement;
        this.clear()
    }

    /** Clear all values */
    clear() {
        this.currentOperation = '';
        this.previousOperation = '';
        this.operation = undefined
        console.log('clear');
    }

    /** Choose number */
    appendNumber(number) {
        this.currentOperation = this.currentOperation.toString() + number.toString() /** Convert number to String to allow more than 1 digit */
        console.log(number)
    }

    /** Choose operator */
    chooseOperation(operation) {
        if (this.currentOperation === '') return /** Prevent double operations */
        if (this.previousOperation !== '') {
            this.compute()
        } /** Calculate existing number  */
        this.operation = operation
        this.previousOperation = this.currentOperation + ' ' + operation
        this.currentOperation = ''
        console.log(operation)
    }

    /** Solve equation */
    compute() {
        let computation
        const prev = parseFloat(this.previousOperation) /** Convert string to number */
        const current = parseFloat(this.currentOperation) /** Convert string to number */
        if (isNaN(prev) || isNaN(current)) return /** Not allow if the user doesn't enter anything */
        switch (this.operation) { /** Computation for all operations */
            case '+':
                computation = prev + current
                break
            case '-':
                computation = prev - current
                break
            case 'x':
                computation = prev * current
                break
            case '÷':
                computation = prev / current
                break
            default:
                return
        }
        this.currentOperation = computation
        this.operation = undefined
        this.previousOperation = ''
        console.log(computation)
    }

    /** Show result */
    updateDisplay() {
        this.currentOperationTextElement.innerText = this.currentOperation
        this.previousOperationTextElement.innerText = this.previousOperation
    }

}

/** Link data attribute from HTML document */
const numberButtons = document.querySelectorAll('[data-number]')
const operationButtons = document.querySelectorAll('[data-operation]')
const equalsButton = document.querySelector('[data-equals]')
const allClearButton = document.querySelector('[data-all-clear]')
const previousOperationTextElement = document.querySelector('[data-previous-Operation]')
const currentOperationTextElement = document.querySelector('[data-current-Operation]')


/** Assign const to class*/
const calculator = new Calculator(previousOperationTextElement, currentOperationTextElement)


/** Click number buttons */
numberButtons.forEach(button => {
    button.addEventListener('click', () => {
        calculator.appendNumber(button.innerText)
        calculator.updateDisplay()
    })
})

/** Click operation buttons */
operationButtons.forEach(button => {
    button.addEventListener('click', () => {
        calculator.chooseOperation(button.innerText)
        calculator.updateDisplay()
    })
})

equalsButton.addEventListener('click', button => {
      calculator.compute()
      calculator.updateDisplay()
      calculator.updateDisplay()
})

allClearButton.addEventListener('click', button => {
      calculator.clear()
      calculator.updateDisplay()
})

console.log('Hello! I love Math!')
/**Source:https://www.youtube.com/watch?v=j59qQ7YWLxwv*/