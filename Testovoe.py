'''
Вопрос №1
На языке Python написать алгоритм (функцию) определения четности целого числа, который будет аналогичен нижеприведенному по функциональности, но отличен по своей сути.
Объяснить плюсы и минусы обеих реализаций.

Пример:

def isEven(value):

      return value % 2 == 0
'''
def is_even(x): return not x & 1
# Побитовая операция сработает быстрее, но программистам привычнее видеть оператор == сравнения, и потому первый вариант читается легче.


'''
Вопрос №2
На языке Python написать минимум по 2 класса реализовывающих циклический буфер FIFO. Объяснить плюсы и минусы каждой реализации.
'''


# Это по большому счёту реализация очереди на пайтон. Принцип FIFO реализуется, класс представляет обёртку над стандартным списком
# Первое что приходит на ум, при просьбе реализовать fifo
class FifoOne:
    def __init__(self, *args):
        self.buffer = list(args)

    def __len__(self):
        return len(self.buffer)

    def __str__(self):
        return 'FifoOne object. Content: '+' '.join(str(x) for x in self.buffer)

    def __iter__(self):
        return (self.pop() for i in range(len(self)))

    def push(self, elem):
        self.buffer.append(elem)

    def pop(self):
        return self.buffer.pop(0) if len(self) > 0 else False  # Тут можно было бы кидать ошибку, зависит от того что нам нужно

# Реализация через обёртку над списком, с добавлением максимальной длины
class FifoTwo:
    def __init__(self, limit: int, *args):
        self.buffer = list(args)[-limit:] #Если нам на входе дали сверх лимита - берём последние
        self.limit = limit

    def __len__(self):
        return len(self.buffer)

    def __str__(self):
        return 'FifoTwo object. Content: '+' '.join(str(x) for x in self.buffer)

    def __iter__(self):
        return (self.pop() for i in range(len(self)))

    def push(self, elem):
        self.buffer.append(elem)
        if len(self) > self.limit: self.buffer.pop(0)

    def pop(self):
        return self.buffer.pop(0) if len(self) > 0 else False


# Реализация исключающая изменение длины списка, в целях оптимизации
class FifoThree:
    def __init__(self, limit:int, *args):
        self.limit = limit
        self.buffer = [x for x in args[-limit:]]
        self.buffer += [False for i in range(limit-len(args))]
        self.index = -1

    def __len__(self):
        return self.limit

    def __str__(self):
        return 'FifoThree object. Content: '+' '.join(str(x) for x in self.buffer if x)

    def __iter__(self):
        return (self.next() for i in range(self.limit))

    def push(self, elem):
        if all(self.buffer):  # Если стек переполнен, мы не добавляем элементы в конец
            return False
        self.buffer[self.end_of_queue()] = elem
        return True

    def next(self):
        self.index = (self.index + 1) % self.limit
        for i in range(self.limit):
            if self.buffer[self.index]:
                break
            self.index = (self.index + 1) % self.limit

        temp = self.buffer[self.index]
        self.buffer[self.index] = False  # Элемент сохранили, забрали, присвоили False
        return temp

    def end_of_queue(self):
        index = self.index
        for i in range(self.index, self.limit + self.index):
            if not self.buffer[i]:
                index = i
                break
        return index


# Реализация односвязного списка без лимита длины
class Elem:  # Служебный класс для элементов списка
    def __init__(self, value, next_elem=None):
        self.value = value
        self.next = next_elem

    def __str__(self):
        return str(self.value)


class FifoFour:
    def __init__(self, *args):
        self.counter = 0
        self.first = None
        self.last = None

        for x in args:
            self.push(x)

    def __len__(self):
        return self.counter

    def __iter__(self):
        return (self.pop() for i in range(self.counter))

    def push(self, value):
        if self.first is None:
            self.first = Elem(value)
            self.last = self.first
        else:
            self.last.next = Elem(value)
            self.last = self.last.next
        self.counter += 1

    def pop(self):
        temp = self.first
        self.first = self.first.next
        self.counter -= 1
        return temp


'''
Вопрос №3

На языке Python предложить алгоритм, который быстрее всего (по процессорным тикам) отсортирует данный ей массив чисел.
Массив может быть любого размера со случайным порядком чисел (в том числе и отсортированным).
Объяснить, почему вы считаете, что функция соответствует заданным критериям.
'''

# Первое что приходит на ум - воспользоваться встроенной функцией пайтона, в рядовых случаях работает адекватно
# Если надо написать самому, тогда такая идея первая:


def my_sort(arr):
    if arr == []:
        return []

    result = [arr[0]]
    for x in arr[1:]:
        if x < result[0]:
            result = [x] + result
        elif x > result[-1]:
            result.append(x)
        else:  # Бинарный поиск по массиву результата
            l = 0
            r = len(result) - 1
            while l < r:
                mid = (l + r) // 2
                if result[mid] > x:
                    r = mid
                else:
                    l = mid + 1
            result = result[:l] + [x] + result[l:]
    return result
'''
В случае уже отсортированного массива мы должны потратить O(n) времени т.к. просто перебираем массив и добавляем его элементы в новый
При максимально перемешанном массиве мы будем использовать бин поиск по уже имеющемуся отсортированному участку массива
Бин поиск по сложности O(log n)
Общая сложность O( n * log n)
'''


#Альтернативное решение:
# Рекурсивная функция с реализацией алгоритма Quicksort
# Должен работать хорошо, потому что признан таким многими специалистами
# Из недостатков - может вызвать переполнение стека вызова функций, и пожрать много памяти на больших длинах списков
def qsort(in_list):
    if in_list == []:
        return []
    else:
        pivot = in_list[0]
        lesser = qsort([x for x in in_list[1:] if x < pivot])
        greater = qsort([x for x in in_list[1:] if x >= pivot])
        return lesser + [pivot] + greater

print(my_sort([6,2,4,8,9,0,7,5,1,3]))
print(qsort([6,2,4,8,9,0,7,5,1,3]))