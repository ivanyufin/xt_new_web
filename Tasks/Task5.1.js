function charRemover(str) {
    str = str.toLowerCase();//Переводим все буквы в маленький регистр

    let words = str.split(' ');//Разбиваем на массив слов

    let repeating = new Array();//Массив повторяемых символов

    for (let i = 0; i < words.length; i++)//Проходимся по массиву слов
    {
        let counts = new Map();//Коллекция, в которой указано сколько раз повторяется определенный символ
        for (let j = 0; j < words[i].length; j++)
            counts.set(words[i][j].toLowerCase(), 0);//Заполняем ее нулями

        for (let j = 0; j < words[i].length; j++) {
            let count = counts.get(words[i][j]);//Получаем количество повторений текущего символа
            counts.set(words[i][j], ++count);//Увеличиваем его на 1
            if (count == 2)//Проверяем сколько раз повторяется
                repeating.push(words[i][j]);//Если больше 1-го раза, то добавляем в массив повторяемых символов
        }
    }

    for (let i = 0; i < repeating.length; i++)//Удаляем все повторения повторяющихся символов
        while (str.indexOf(repeating[i]) != -1)
            str = str.replace(repeating[i], '');

    console.log(str);
}

charRemover("Hello World");