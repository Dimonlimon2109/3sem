//task1
const numbers = [1, 2, 3, 4, 5];

const [y] = numbers;

console.log(y);
//task2
const user = {
    name: 'John',
    age: 30,
  };
  
  const admin = {
    admin: true,
    ...user,
  };
  
  console.log(admin);

  //task3
  let store = {
    state: {
        profilePage: {
            posts:[
                {id: 1, message: 'Hi', likesCount: 12},
                {id: 2, message: 'By', likesCount: 1},
            ],
            newPostText: 'About me',
        },
        dialogsPage: {
            dialogs: [
                {id: 1, name: 'Valera'},
                {id: 2, name: 'Andrey'},
                {id: 3, name: 'Sasha'},
                {id: 4, name: 'Viktor'},
            ],
            messages: [
                {id: 1, message: 'hi'},
                {id: 2, message: 'hi hi'},
                {id: 3, message: 'hi hi hi'},
            ],
        },
        sidebar: [],
    },
  }
  const {
    state: {
      profilePage: { posts },
      dialogsPage: { dialogs, messages },
    },
  } = store;
  posts.forEach(post => {
    console.log(post.likesCount)
  });
  const filteredDialogs = dialogs.filter(dialog => dialog.id % 2 === 0);
console.log(filteredDialogs);

const updatedMessages = messages.map(message => ({ id: message.id, message: 'Hello user' }));
console.log(updatedMessages);
  //task4
  let tasks = [
    { id: 1, title: "HTML&CSS", isDone: true},
    { id: 2, title: "JS", isDone: true},
    { id: 3, title: "ReactJS", isDone: false},
    { id: 4, title: "Rest API", isDone: false},
    { id: 5, title: "GraphQL", isDone: false},
  ]
  let task = {id: 10, title: "Python", isDone: true};
  tasks = {tasks, task};
  console.log(tasks);
  //task5
  function sumValues(x, y, z) { 
    return x + y + z;
  }
  
  const array = [1, 2, 3];
  
  const result = sumValues(...array);
  
  console.log(result); // Выводит: 6