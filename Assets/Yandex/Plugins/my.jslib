mergeInto(LibraryManager.library, {

    GetLang: function() {
        // Проверяем, что объект ysdk существует
        try {
            var lang = ysdk.environment.i18n.lang;
            var bufferSize = lengthBytesUTF8(lang) + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(lang, buffer, bufferSize);
            return buffer;
        } catch {
            // Обработка случая, когда ysdk не существует
            console.error("Ошибка: ysdk не создан или не инициализирован");
            return null;  // Или другой код ошибки в зависимости от вашего контекста
        }
    },


  });