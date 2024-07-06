//1.Имеется список товаров. Реализуйте функции, которые добавляют, удаляют товар из списка, проверяет наличие товара. 
//Определите количество имеющего товара. Используйте коллекцию Set.  
const productSet = new Set();

function addProduct(product) {
  productSet.add(product);
  console.log(`${product} был добавлен в список товаров.`);
}


function removeProduct(product) {
  if (productSet.has(product)) {
    productSet.delete(product);
    console.log(`${product} был удален из списка товаров.`);
  } else {
    console.log(`${product} не найден в списке товаров.`);
  }
}

function hasProduct(product) {
  if (productSet.has(product)) {
    console.log(`${product} есть в списке товаров.`);
  } else {
    console.log(`${product} отсутствует в списке товаров.`);
  }
}

function countProducts() {
  console.log(`Всего товаров в списке: ${productSet.size}`);
}

addProduct("Телевизор");
addProduct("Компьютер");
addProduct("Телефон");

hasProduct("Компьютер");
hasProduct("Сок");

removeProduct("Телефон");
removeProduct("Приставка");

countProducts();
for(let product of productSet)
{
  console.log(product);
}
//2.Используя коллекцию Set создайте список студентов. О каждом студенте содержится информация: номер зачетки, группа, ФИО. 
//Создайте функции, которые:
//- добавляют студента, 
//- удаляют по номеру, 
//- фильтруют список по группе, 
//- сортируют по номеру зачетки. 

const studentsSet = new Set();

function Student(zachetkaNumber, group, fullName) {
  this.zachetkaNumber = zachetkaNumber;
  this.group = group;
  this.fullName = fullName;
}

function addStudent(student) {
  studentsSet.add(student);
  console.log(`${student.fullName} был добавлен в список студентов.`);
}

function removeStudentByZachetkaNumber(zachetkaNumber) {
  for (const student of studentsSet) {
    if (student.zachetkaNumber === zachetkaNumber) {
      studentsSet.delete(student);
      console.log(`${student.fullName} был удален из списка студентов.`);
      return;
    }
  }
  console.log(`Студент с номером зачетки ${zachetkaNumber} не найден в списке.`);
}

function filterStudentsByGroup(group) {
  const filteredStudents = [...studentsSet].filter(student => student.group === group);
  return filteredStudents;
}

function sortStudentsByZachetkaNumber() {
  const sortedStudents = [...studentsSet].sort((a, b) => a.zachetkaNumber - b.zachetkaNumber);
  return sortedStudents;
}

const student1 = new Student(12345, "5", "Иванов Иван Иванович");
const student2 = new Student(54321, "4", "Петров Петр Петрович");

addStudent(student1);
addStudent(student2);

removeStudentByZachetkaNumber(12345);

const student3 = new Student(67890, "5", "Верчук Родион Харитонович");
const student4 = new Student(77777, "5", "Баранчук Константин Александрович");
addStudent(student3);
addStudent(student4);

const filteredStudents = filterStudentsByGroup("5");
console.log('Студенты из группы 5:');
for(let student of filteredStudents)
{
  console.log(`Номер зачетки: ${student.zachetkaNumber}, Группа: ${student.group}, ФИО: ${student.fullName}`);
}

const sortedStudents = sortStudentsByZachetkaNumber();
console.log("Список студентов, отсортированный по номеру зачетки:");
for(let student of sortedStudents)
{
  console.log(`Номер зачетки: ${student.zachetkaNumber}, Группа: ${student.group}, ФИО: ${student.fullName}`);
}

//3.	Используя коллекцию Map и ее методы, реализуйте хранилище товаров. 
//В корзине хранится информация о товаре: id (ключ в коллекции Map), название, количество товара, цена. Разработайте функции, которые:  
//- добавляют товар, 
//- удаляют товар из списка по id, 
//- удаляют товары по названию (учтите, что названия товаров могут повторяться), 
//- изменяют количество каждого товара,
//- изменяют стоимость товара.
//Рассчитайте количество позиций в списке и сумму стоимости всех товаров.
// Создаем пустую Map для хранения товаров
const productStore = new Map();


function addProductMap(id, name, quantity, price) {
  if (productStore.has(id)) {
    console.log(`Товар с id ${id} уже существует в корзине.`);
  } else {
    const product = { name, quantity, price };
    productStore.set(id, product);
    console.log(`Товар "${name}" был добавлен в корзину.`);
  }
}

function removeProductByIdMap(id) {
  if (productStore.has(id)) {
    const { name } = productStore.get(id);
    productStore.delete(id);
    console.log(`Товар "${name}" с id ${id} был удален из корзины.`);
  } else {
    console.log(`Товар с id ${id} не найден в корзине.`);
  }
}

function removeProductsByNameMap(name) {
  let deletedCount = 0;
  for (const [id, product] of productStore) {
    if (product.name === name) {
      productStore.delete(id);
      deletedCount++;
    }
  }
  if (deletedCount > 0) {
    console.log(`Удалено ${deletedCount} товаров с названием "${name}".`);
  } else {
    console.log(`Товары с названием "${name}" не найдены в корзине.`);
  }
}

function updateProductQuantityMap(id, newQuantity) {
  if (productStore.has(id)) {
    const product = productStore.get(id);
    product.quantity = newQuantity;
    console.log(`Количество товара "${product.name}" (id ${id}) изменено на ${newQuantity}.`);
  } else {
    console.log(`Товар с id ${id} не найден в корзине.`);
  }
}

function updateProductPriceMap(id, newPrice) {
  if (productStore.has(id)) {
    const product = productStore.get(id);
    product.price = newPrice;
    console.log(`Стоимость товара "${product.name}" (id ${id}) изменена на ${newPrice}.`);
  } else {
    console.log(`Товар с id ${id} не найден в корзине.`);
  }
}

function countItemsMap() {
  console.log(`В корзине ${productStore.size} товаров.`);
}

function calculateTotalPriceMap() {
  let totalPrice = 0;
  for (const { quantity, price } of productStore.values()) {
    totalPrice += quantity * price;
  }
  console.log(`Сумма стоимости всех товаров в корзине: $${totalPrice.toFixed(2)}`);
}

addProductMap(1, "Молоко", 3, 2.5);
addProductMap(2, "Хлеб", 2, 1.0);
addProductMap(3, "Яйца", 12, 0.5);

countItemsMap();
calculateTotalPriceMap();

updateProductQuantityMap(2, 5);
updateProductPriceMap(3, 0.6);

countItemsMap();
calculateTotalPriceMap();

removeProductByIdMap(1);
removeProductsByNameMap("Хлеб");

countItemsMap();
calculateTotalPriceMap();
for(let product of productStore)
{
  console.log(product);
}




//4.	Создайте коллекцию WeakMap для кеширования результатов функции. 
//WeakMap должен содержать входные параметры функции и результаты расчета.  
//Функция должна выполняться только в том случае, если в кэше нет данных, иначе – берем данные из WeakMap.
const cache = new WeakMap();

function calculateResult(input) {
  if (cache.has(input)) {
    console.log('Результат взят из кэша:', cache.get(input));
    return cache.get(input);
  }

  const result = input.value * 2;

  cache.set(input, result);

  return result;
}

// Пример использования функции и кэширования
const input1 = { value: 5 }; // Оборачиваем значение в объект
const input2 = { value: 10 };
const input3 = { value: 5 };
console.log('Результат функции для input1:', calculateResult(input1)); // Вычисление выполнится и результат будет закэширован
console.log('Результат функции для input2:', calculateResult(input2)); // Вычисление выполнится и результат будет закэширован
console.log('Результат функции для input1:', calculateResult(input3)); // Результат будет взят из кэша