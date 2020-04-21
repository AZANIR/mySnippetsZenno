// Удаление всех строк из списка по полному совпадению со значением переменной
IZennoList list = project.Lists["List"]; // список проекта
string str = project.Variables["Var"].Value; // переменная проекта со значением
lock (SyncObjects.ListSyncer) {
 for (int i = 0; i < list.Count; i++) {
  if (list[i] == str) {
   list.RemoveAt(i);
   i--;
  }
 }
}


// Удаление первой строки из списка по полному совпадению со значением переменной
IZennoList list = project.Lists["List"]; // список проекта
string str = project.Variables["Var"].Value; // переменная проекта со значением
lock (SyncObjects.ListSyncer) {
 for (int i = 0; i < list.Count; i++) {
  if (list[i] == str) {
   list.RemoveAt(i);
   break;
  }
 }
}


// Удаление всех строк из списка по частичному совпадению со значением переменной
IZennoList list = project.Lists["List"]; // список проекта
string str = project.Variables["Var"].Value; // переменная проекта со значением
lock (SyncObjects.ListSyncer) {
 for (int i = 0; i < list.Count; i++) {
  if (list[i].Contains(str)) {
   list.RemoveAt(i);
   i--;
  }
 }
}


// Удаление первой строки из списка по частичному совпадению со значением переменной
IZennoList list = project.Lists["List"]; // список проекта
string str = project.Variables["Var"].Value; // переменная проекта со значением
lock (SyncObjects.ListSyncer) {
 for (int i = 0; i < list.Count; i++) {
  if (list[i].Contains(str)) {
   list.RemoveAt(i);
   break;
  }
 }
}