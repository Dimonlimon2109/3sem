//var 1
function makeCounter(){
    let currentCount = 1;
    return function(){
        return currentCount++;
    };
}

let counter = makeCounter();

console.log(counter() );
console.log(counter() );
console.log(counter() );
let counter2 = makeCounter();
console.log(counter2() );
//var 2
let currentCount = 1;
function makeCounter2(){
    return function(){
        return currentCount++;
    };
}

let counter3 = makeCounter2();
let counter4 = makeCounter2();

console.log(counter3() );
console.log(counter3() );
console.log(counter4() );
console.log(counter4() );

//2
console.log("///////////////////////2");
function calculateVolume(length) {
    return function(width) {
        return function(height) {
            return length * width * height;
        };
    };
}

// Пример использования
const volume = calculateVolume(2)(3)(4);
console.log("Объем прямоугольного парчаллелепипеда:", volume);
console.log("///////////////3");

function* moveGenerator() {
    let x = 0;
    let y = 0;
    for (let i = 0; i < 10; i++) {
        let direction = yield {x, y}; // переместил объявление direction в начало цикла
        switch (direction) {
            case 'left':
                x--;
                break;
            case 'right':
                x++;
                break;
            case 'up':
                y++;
                break;
            case 'down':
                y--;
                break;
            default:
                console.log('Неверная команда. Используйте "left", "right", "up" или "down".');
                i--; // Повторить текущий шаг, так как команда была неверной
                break;
        }
    }

    console.log('Движение завершено.');
}

const iterator = moveGenerator();
step = iterator.next();
const userInput = prompt('Введите команду (left, right, up, down):');
step = iterator.next(userInput);
while (!step.done) {
    console.log(`Текущие координаты: (${step.value.x}, ${step.value.y})`);
    const userInput = prompt('Введите команду (left, right, up, down):');
    step = iterator.next(userInput);
}


console.log("/////////////////4");
// Создание переменной и функции без явного указания области видимости
globalVar = "Я глобальная переменная";

function globalFunction() {
    console.log("Я глобальная функция");
}
console.log(window);            
console.log(window.globalVar);      
console.log(window.globalFunction); 

window.globalVar = "Новое значение глобальной переменной";
window.globalFunction = function() {
    console.log("Новый код глобальной функции");
};

console.log(window.globalVar);       
window.globalFunction();            
