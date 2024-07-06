let products = {
    "Shoes": {
        "Boots": [
            {
                "unique_number": 1,
                "size": 42,
                "color": "black",
                "price": 5000
            },
            {
                "unique_number": 2,
                "size": 38,
                "color": "brown",
                "price": 4500
            }
        ],
        "Sneakers": [
            {
                "unique_number": 3,
                "size": 40,
                "color": "white",
                "price": 3000
            },
            {
                "unique_number": 4,
                "size": 37,
                "color": "blue",
                "price": 3500
            }
        ],
        "Sandals": [
            {
                "unique_number": 5,
                "size": 39,
                "color": "beige",
                "price": 2000
            },
            {
                "unique_number": 6,
                "size": 36,
                "color": "black",
                "price": 2500
            }
        ]
    },
}
function filterShoes(products, minPrice, maxPrice, size, color) {
    const filteredItems = [];

    for (const category in products) {
        for (const shoeType in products[category]) {
            for (const item of products[category][shoeType]) {
                if ((minPrice === null || (minPrice !== null && item.price >= minPrice)) &&
                    (maxPrice === null || (maxPrice !== null && item.price <= maxPrice)) &&
                    (size === null || (size !== null && item.size === size)) &&
                    (color === null || (color !== null && item.color.toLowerCase() === color.toLowerCase()))) {
                    filteredItems.push(item.unique_number);
                }
            }
        }
    }

    return filteredItems;
}

const minPrice = 2400;
const maxPrice = 6000;
const shoeSize = 42;
const shoeColor = "black";

const result = filterShoes(products, minPrice, maxPrice, shoeSize, shoeColor);

if (result.length > 0) {
    console.log(`Товары, соответствующие условиям фильтрации: ${result}`);
} else {
    console.log("Нет товаров, соответствующих заданным условиям.");
}


const newProducts = {
    "Shoes": {
        "Boots": [
            {
                "unique_number": 1,
                "size": 42,
                "color": "black",
                "base_price": 5000,
                "discount": 10, // Процент скидки
                get price() {
                    if(this.discount != 0){
                    const discountAmount = (this.base_price * this.discount) / 100;
                    return this.base_price - discountAmount;
                    }
                    else
                    {
                        return this.base_price;
                    }
                }
            },
        ],
        "Sneakers": [
            {
                "unique_number": 2,
                "size": 38,
                "color": "white",
                "base_price": 3000,
                "discount": 5,
                get price() {
                    if(this.discount != 0){
                    const discountAmount = (this.base_price * this.discount) / 100;
                    return this.base_price - discountAmount;
                    }
                    else
                    {
                        return this.base_price;
                    }
                }
            },
        ],
        "Sandals": [
            {
                "unique_number": 3,
                "size": 39,
                "color": "beige",
                "base_price": 2000,
                "discount": 0,
                get price() {
                    if(this.discount != 0){
                    const discountAmount = (this.base_price * this.discount) / 100;
                    return this.base_price - discountAmount;
                    }
                    else
                    {
                        return this.base_price;
                    }
                }
            }
        ]
    }
};

const bootsPrice = newProducts.Shoes.Boots[0].price;
console.log(`Цена ботинок после скидки: ${bootsPrice}`);

Object.defineProperty(newProducts.Shoes.Boots[0], "price", {
    writable: true,  // Свойство можно изменять
    enumerable: true,  // Свойство можно перечислять
    configurable: false  // Свойство нельзя удалять
});

Object.defineProperty(newProducts.Shoes.Boots[0], "unique_number", {
    writable: false,  // Свойство нельзя изменять
    enumerable: true,  // Свойство можно перечислять
    configurable: false  // Свойство нельзя удалять
});

newProducts.Shoes.Boots[0].price = 4500;  // Разрешено изменение цены
newProducts.Shoes.Boots[0].unique_number = 10;
delete newProducts.Shoes.Boots[0].unique_number;  // Запрещено удаление уникального номера
console.log(newProducts.Shoes.Boots[0].price);  // Выведет измененную цену
console.log(newProducts.Shoes.Boots[0].unique_number);  // Выведет уникальный номер (нельзя удалить)



function Sneakers(unique_number, size, color, base_price, discount) {
    this.unique_number = unique_number;
    this.size = size;
    this.color = color;
    this.base_price = base_price;
    this.discount = discount;
    this.price = function () {
        if (this.discount != 0) {
            const discountAmount = (this.base_price * this.discount) / 100;
            return this.base_price - discountAmount;
        } else {
            return this.base_price;
        }
    };
}

// Пример использования функции-конструктора для создания объекта обуви
const boots1 = new Sneakers(1, 42, "black", 5000, 10);
const boots2 = new Sneakers(2, 38, "brown", 4500, 5);

console.log("Цена ботинок 1:", boots1.price());

console.log("Цена ботинок 2:", boots2.price());

function Shoe(unique_number, size, color, base_price, discount) {
    this.unique_number = unique_number;
    this.size = size;
    this.color = color;
    this.base_price = base_price;
    this.discount = discount;
    this.price = function () {
        if (this.discount != 0) {
            const discountAmount = (this.base_price * this.discount) / 100;
            return this.base_price - discountAmount;
        } else {
            return this.base_price;
        }
    };
}


const allProducts = {
    "Shoes": {
        "Boots": [
            new Shoe(1, 42, "black", 5000, 10),
        ],
        "Sneakers": [
            new Shoe(2, 38, "white", 3000, 5),
        ],
        "Sandals": [
            new Shoe(3, 39, "beige", 2000, 0),
        ]
    }
};
for (const category in allProducts) {
    console.log(`Category: ${category}`);

    for (const subCategory in allProducts[category]) {
        console.log(`  Subcategory: ${subCategory}`);

        for (const product of allProducts[category][subCategory]) {
            console.log(`    Product: ${product.unique_number}`);
            console.log(`      Size: ${product.size}`);
            console.log(`      Color: ${product.color}`);
            console.log(`      Base Price: ${product.base_price}`);
            console.log(`      Discount: ${product.discount}%`);
            console.log(`      Price after Discount: ${product.price()}`);
            console.log('-----------------------------------');
        }
    }
}