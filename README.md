CRUD интерфейс для доступа к файлам, хранимым в папке wwwrooot/Storage </br>
Методы:</br>
[get] GetList() Выдает список объектов типа FileInfo всех файлов в хранилище.</br>
[get {string: name}] GetFile(string name) Возвращает файл с именем name (расширение тоже учитывается) в виде потока.</br>
[post {IFromFile file}] Add(IFromFile) асинхронно сохраняет файл в хранилище.</br>
[delete {string name}] Delete(string name) Операция удаления файла с именем name (расширение тоже учитывается).</br>
