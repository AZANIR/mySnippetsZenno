project.Context["function"] = (Action) (() => { // объявление и начало тела функции
Tab tab = instance.ActiveTab; //работа с активным табом
  instance.Click(5, 7, 230, 215, "Left", "Normal"); //наполнение функции. в данном случае клик по координатам.
}); // конец тела функции
 
  project.Context["function"]();  // вызов функции.