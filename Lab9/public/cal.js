const numbs = document.getElementsByClassName('butnum')
const mathOperators = document.getElementsByClassName('but')
const screen = document.getElementById('screen')
const execute = document.getElementById('doMath')
const clear = document.getElementById('clear')
const storedValue = document.getElementById(`storedValue`)
const del = document.getElementById('delete')
const tds = document.getElementsByTagName('td')

var temp
var operator = null
var number1 = null
var number2 = null
var result = null
var tempOperator = null
var mathContinue = true
var length = numbs.length
var length2 = mathOperators.length


del.addEventListener('click',function(){screen.value= screen.value.slice(0,-1),highLight(this)})
execute.addEventListener('click',function(){executeMath(),highLight(this)})
clear.addEventListener('click',function(){clearMath(),highLight(this)})


for(var i =0; i<length;i++){
        numbs[i].addEventListener('click',function(event){
            var numb = (event.target.textContent)    
            putIntoScreen(numb)       
            highLight(this)
        }) 
    }
    
for(var i =0; i<length2;i++){
        mathOperators[i].addEventListener('click',function(event){          
            getOperator(event)
            highLight(this)
        }) 
    }

function showStoredValue(){
    storedValue.textContent = `${number1}` + operator
}
function getOperator(event){          
        var temp = event.target.textContent

        if (operator !== null) mathContinue = true    

            if ((temp=='-')&&(operator!==null)){                    //Если - не опрератор, но отметка отрицательного числа 
                screen.value+=temp
            }  
            else if ((number1!==null)&&(mathContinue)){             //Есть первое число, второе только что введён, но
                number2 = parseFloat(screen.value)                  //не нажимать кпопу (=), а кнопку оператор, тогда надо
                number1 = doMath()                                  //вычислить новое первое число = (первое число +-*/ второе число
                screen.value = ''                                   
                operator = temp    
                showStoredValue()  
            } 
            else{                                                   //Если нет первого числа, то читать его из экрана
                number1 = screen.value
                screen.value = '' 
                operator = temp    
                showStoredValue()   
            }
                    
}

function putIntoScreen(but){
    var input = but
    screen.value +=input
}
function clearMath(){
    number1 = null
    number2 = null
    result = null
    operator =null
    screen.value = ''
}
function mathDone(){
    result = doMath()
    tempOperator = operator
    screen.value = result
    number1 = result
    number2 = null
    operator = null
    mathContinue=false
    storedValue.textContent=''
}
function doMath(){  
    number1 = parseFloat(number1)  
    screen.value = ''
    switch(operator){
        case '+': 
            result = number1+number2 
            break
        case '-':
            result = number1-number2 
            break
        case '*':
            result = number1*number2 
            break
        case '/':
            result = number1/number2 
            break         
    }
    return result
    
}
function executeMath(){
    number2 = parseFloat(screen.value)
    if ((number2 !==null)&&(operator!==null))
        mathDone()
 }
function highLight(button){
    if (temp) temp.style.border="none"
    button.style.border = "1.5px solid blue"
    temp = button
}







