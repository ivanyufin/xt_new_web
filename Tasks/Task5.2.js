let arithemicSymbol = ['+', '-', '*', '/'];//������ �������������� ��������

function calculate(str) {
    //������� ��� �������
    while (str.indexOf(' ') != -1)
        str = str.replace(' ', '');
    let i = 0;
    //����� ������ �� ������, ���� � ��� ���� ���� ���� �������������� ������
    while (str.indexOf(arithemicSymbol[0]) != -1 || str.indexOf(arithemicSymbol[1]) != -1 || str.indexOf(arithemicSymbol[2]) != -1 || str.indexOf(arithemicSymbol[3]) != -1) {
        let leftOperand;//����� ������� ���������
        let rightOperand;//������ ������� ���������
        for (let j = 0; j < arithemicSymbol.length; j++)//���������� �������������� �������
        {
            if (str[i] == arithemicSymbol[j])//���� �� ���� �� ����������
            {
                leftOperand = str.substring(0, i);//����� ������� - �� ������ ������ �� �������� ��������������� �������

                //������� ������ �������, ������� ������ � �������, �������� �� ������� �������������� � �� ����� ������
                rightOperand = getRightOperand(str.substring(i + 1, str.length));
                let otvet = 0;
                switch (arithemicSymbol[j])//������� �������������� �����
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
                //� ����������� ������ ��������� ��������� �������������� ���������� �������
                str = str.replace(leftOperand + arithemicSymbol[j] + rightOperand, otvet);
                i = 0;//������ � ������ ������
            }
        }
        i++;
    }
    return parseFloat(str).toFixed(2);
}

function getRightOperand(str) {
    let rightOperand = "";
    let indexArithmeticSymbol = -1;//������ ����������(���� ����) ��������������� �������
    for (let i = 0; i < str.length; i++)
        if (indexArithmeticSymbol == -1)//���� ��� �� ����� ������
            for (let j = 0; j < arithemicSymbol.length; j++)//���������� �������������� �������
            {
                if (str.indexOf(arithemicSymbol[j]) != -1)//���� ������� �������������� ������ ������������ � ������
                {
                    if (str[i] == arithemicSymbol[j])//��������� �� ������� ������ � ��������������
                    {
                        indexArithmeticSymbol = i;//���� ��, ������ ���������� ��� ������
                        break;//� ������� �� �����
                    }
                }
                else//���� �������� ��������������� ������� � ������ ���, �� ������ ���������� ���
                    continue;
            }
    if (indexArithmeticSymbol != -1)//���� �������������� ������ ��� ������
    {
        return str.substring(0, indexArithmeticSymbol);//������ ������� - �� ������ ������ �� ���������� �������
    }
    else//���� �� ��� ������
    {
        return str;//���������� ������ ������
    }
}

console.log('3.5+4*10-5.3/5=' + calculate('3.5+4*10-5.3/5'));