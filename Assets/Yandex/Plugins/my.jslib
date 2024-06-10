mergeInto(LibraryManager.library, {
    
    GetLang: function() {
        try {
            var lang = ysdk.environment.i18n.lang;
            console.log("print ysdk.environment.i18n.lang " + lang);
            var bufferSize = lengthBytesUTF8(lang) + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(lang, buffer, bufferSize);
            return buffer;
        } catch {
            return null;  
        }
    },


  });