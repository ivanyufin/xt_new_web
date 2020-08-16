let arithemicSymbol = ['+', '-', '*', '/'];//Массив арифметических символов

function calculate(str) {
    //Убираем все пробелы
    while (str.indexOf(' ') != -1)
        str = str.replace(' ', '');
    let i = 0;
    //Будем ходить по строке, пока в ней есть хоть один арифметический символ
    while (str.indexOf(arithemicSymbol[0]) != -1 || str.indexOf(arithemicSymbol[1]) != -1 || str.indexOf(arithemicSymbol[2]) != -1 || str.indexOf(arithemicSymbol[3]) != -1) {
        let leftOperand;//Левый операнд выражения
        let rightOperand;//Правый операнд выражения
        for (let j = 0; j < arithemicSymbol.length; j++)//Перебираем арифметические символы
        {
            if (str[i] == arithemicSymbol[j])//Если на пути он встретился
            {
                leftOperand = str.substring(0, i);//Левый операнд - от начала строки до текущего арифметического символа

                //Находим правый операнд, начиная искать с символа, стоящего за текущим арифметическим и до конца строки
                rightOperand = getRightOperand(str.substring(i + 1, str.length));
                let otvet = 0;
                switch (arithemicSymbol[j])//Считаем соответственно ответ
                {
                    case "+":
                        otvet = +leftOperand + +rightOperand;
                        break;
                    case "-":
                        otvet = +leftOperand - +rightOperand;
                        break;
                    case "*":
                        otvet = +leftOperand * +rightOperand;
                        break;
                    case "/":
                        otvet = +leftOperand / +rightOperand;
                        break;
                }
                //В изначальной строке считаемое выражение перезаписываем полученным ответов
                str = str.replace(leftOperand + arithemicSymbol[j] + rightOperand, otvet);
                i = 0;//Уходим в начало строки
            }
        }
        i++;
    }
    return parseFloat(str).toFixed(2);
}

function getRightOperand(str) {
    let rightOperand = "";
    let indexArithmeticSymbol = -1;//Индекс найденного(если есть) арифметического символа
    for (let i = 0; i < str.length; i++)
        if (indexArithmeticSymbol == -1)//Если еще не нашли символ
            for (let j = 0; j < arithemicSymbol.length; j++)//Перебираем арифметические символы
            {
                if (str.indexOf(arithemicSymbol[j]) != -1)//Если текущий арифметический символ присутствует в строке
                {
                    if (str[i] == arithemicSymbol[j])//Совпадает ли текущий символ с арифметическим
                    {
                        indexArithmeticSymbol = i;//Если да, значит запоминаем его индекс
                        break;//И выходим из цикла
                    }
                }
                else//Если текущего арифметического символа в строке нет, то просто пропускаем его
                    continue;
            }
    if (indexArithmeticSymbol != -1)//Если арифметический символ был найден
    {
        return str.substring(0, indexArithmeticSymbol);//Правый операнд - от начала строки до найденного символа
    }
    else//Если не был найден
    {
        return str;//Возвращаем полную строку
    }
}

console.log('3.5+4*10-5.3/5=' + calculate('3.5+4*10-5.3/5'));