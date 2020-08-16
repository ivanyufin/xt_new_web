function charRemover(str) {
    str = str.toLowerCase();//��������� ��� ����� � ��������� �������

    let words = str.split(' ');//��������� �� ������ ����

    let repeating = new Array();//������ ����������� ��������

    for (let i = 0; i < words.length; i++)//���������� �� ������� ����
    {
        let counts = new Map();//���������, � ������� ������� ������� ��� ����������� ������������ ������
        for (let j = 0; j < words[i].length; j++)
            counts.set(words[i][j].toLowerCase(), 0);//��������� �� ������

        for (let j = 0; j < words[i].length; j++) {
            let count = counts.get(words[i][j]);//�������� ���������� ���������� �������� �������
            counts.set(words[i][j], ++count);//����������� ��� �� 1
            if (count == 2)//��������� ������� ��� �����������
                repeating.push(words[i][j]);//���� ������ 1-�� ����, �� ��������� � ������ ����������� ��������
        }
    }

    for (let i = 0; i < repeating.length; i++)//������� ��� ���������� ������������� ��������
        while (str.indexOf(repeating[i]) != -1)
            str = str.replace(repeating[i], '');

    console.log(str);
}

charRemover("Hello World");