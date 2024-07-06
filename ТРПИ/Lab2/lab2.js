///1
function basicOperation(operation, value1, value2)
{
    if(operation == '+')
        return value1 + value2
    else if(operation == '-')
    return value1 - value2
else if(operation == '*')
return value1 * value2
else if(operation == '/')
return value1 / value2
else
    return undefined
}
alert("5 + 10 = " + basicOperation('+', 5, 10))
alert("5 - 10 = " + basicOperation('-', 5, 10))
alert("5 * 10 = " + basicOperation('*', 5, 10))
alert("5 / 10 = " + basicOperation('/', 5, 10))
///2
function sum_of_cubes(n)
{
    let sum = 0
    for(let i = 0; i <= n; i++)
    sum += Math.pow(i, 3)
return sum
}
let n = prompt("Введите число: ")
alert("Сумма кубов чисел до " + n + " включительно = " + sum_of_cubes(n))
///3
function average(arr)
{
    let sum = 0
    for(let i = 0; i < arr.length; i++)
    sum += arr[i]
return (sum / arr.length)
}
let numbers = [10,20,30,40]
alert("Среднее арифметическое: " + average(numbers))
///4
function reverse(str)
{
    let reversed_str = "";
    for(let i = str.length - 1; i >= 0; i--)
    {
    if((str[i] >= 'A' && str[i] <='Z') || (str[i] >='a' && str[i] <= 'z'))
    {
    reversed_str += str[i]
    }
    }
    return reversed_str
}
let str = prompt("Введите строку")
alert(reverse(str))
///5
function repeat(n, s)
{
    let str = ""
    for(let i = 0; i < n; i++)
    str += s
return str
}
let s = prompt("Введите строку")
n = prompt("Введите число повторений слова")
alert(repeat(n,s))
///6
function unique_strs(arr1, arr2) {
    let arr3 = [];
    for (let str1 of arr1) {
      if (!arr2.includes(str1)) {
        arr3.push(str1);
      }
    }
    return arr3;
  }
  
  let arr1 = ["apple", "banana", "cherry"];
  let arr2 = ["banana", "orange"];
alert(unique_strs(arr1, arr2));