//1)
let a = 5 //тип number
let name = "Name" //тип string
let i = 0; //тип number
let double = 0.23 //number
let result = 1/0 //undefined
let answer = true //boolean
let no = null //null
///////////////////////////2)
console.log('2)')
let S1 = 45*21
let S2 = 5 *5
result2 = S1 / S2
console.log(result2)
console.log('В четырехугольник A поместится ' + result2 + ' квадратов B ')
/////////////////////////////////////////////3)
console.log('3)')
let i_2 = 2
let a_2 = i_2
let b_2 = i_2
console.log(++a_2 > b_2++)
///////////////////////////////////////4)
console.log('4)')
console.log('Котик'>'котик' ? true : false)
console.log('Котик' > 'китик' ? true : false)
console.log('Кот'>'Котик' ? true : false)
console.log('Привет'>'Пока' ? true : false)
console.log( 73 >'53' ? true : false)
console.log(false > 0 ? true : false)
console.log(54 > true ? true : false)
console.log( 123 > false ? true : false)
console.log( true >'3' ? true : false)
console.log( 3 >'5мм' ? true : false)
console.log( 8 >'-2' ? true : false)
console.log(34 >'34' ? true : false)
console.log( null == undefined ? true : false)
//5
var prepod_fio = "Белодед Николай Иванович"
var prepod_io = "Николай Иванович"
var prepod_i = "Николай"
var nickname = prompt("Введите имя: " )
if(prepod_fio == nickname || prepod_io == nickname || prepod_i == nickname || prepod_fio.toUpperCase() == nickname || prepod_io.toUpperCase() == nickname || prepod_i.toUpperCase() == nickname )
alert("Данные введены верно!")
else
alert("Неверно введены данные):")
//6
let russian = prompt('Сдал ли студент русский? (+ Да, - Нет)')
let math = prompt('Сдал ли студент математику? (+ Да, - Нет)')
let english = prompt('Сдал ли студент английский? (+ Да, - Нет)')
if(russian == '+' && english  == '+' && math == '+')
alert('Студент переведен на 2 курс!')
else if(russian == '-' && english == '-' && math == '-')
alert('Студент отчислен):')
else
alert('Студенту предстоит пересдача):')
////////////////////////////////7)
console.log('7)')
console.log(true + true)
console.log(0 + "5")
console.log(5 + "мм")
console.log(8/Infinity)
console.log(9 * "\n9")
console.log(null - 1)
console.log("5" - 2)
console.log("5px" - 3)
console.log(true - 3)
console.log(7 || 0)
////////////////////////8)
console.log('8)')
var arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
for(let i = 1; i < arr.length + 1; i++)
{
    if(i % 2 != 0)
    arr[i - 1] = i + "мм"
    else 
    arr[i- 1] += 2
    console.log(arr[i - 1])     
}
//9)
var week = ["понедельник", "вторник", "среда", "четверг", "пятница", "суббота", "воскресенье"]
var number_of_day = prompt("Введите номер дня недели: ")
alert(week[number_of_day - 1])
let obj = {};
for (let count = 0; count < 10; count++) {
    obj[count] = count + 1;

    if (obj[count] % 2 == 0)
        obj[count] += 2

    if (obj[count] % 2 != 0)
    obj[count] += "мм"

    alert(obj[count])
}
///////////////////////10)
console.log("10)")
const sum = function (param1, param2, param3 = 18)
{
    return param3 + param1 + param2
}
console.log(sum('y', prompt("Введите третий параметр: ")))
//11)
let A = prompt("Сторона a")
let B = prompt("Сторона b")
function params1(a,b) {
if(a == b)
return 4*a
else
return a*b
}
const params2 = (a,b) => {
    if(a == b)
    return 4*a
    else
    return a*b
}
const params3 = function(a,b)
{
    if(a == b)
return 4*a
else
return a*b
}
alert(params1(A,B))
alert(params2(A,B))
alert(params3(A,B))
