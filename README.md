CRUD интерфейс для доступа к файлам, хранимым в папке wwwrooot/Storage
Методы:
[get] GetList() Выдает список объектов типа FileInfo всех файлов в хранилище.
[get {string: name}] GetFile(string name) Возвращает файл с именем name (расширение тоже учитывается) в виде потока.
[post {IFromFile file}] Add(IFromFile) асинхронно сохраняет файл в хранилище.
[delete {string name}] Delete(string name) Операция удаления файла с именем name (расширение тоже учитывается).
