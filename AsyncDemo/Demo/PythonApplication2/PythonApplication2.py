#print("hello, world")
#object=input("enter an object")
#print(object,type(object),len(object))
counter = "100"
print(counter)

a = 100
b = 20 
if a > b:
    print("aaa")
else:
    print("bbb")

#name =input("输入名称")
#print('Hi, %s, you have $%d.' % ('Michael', 1000000))
a = 'qwertt'
b = 'e'
if b in a:
    print('yes')
else:
    print('no')

i=0
while i < len(a):
    print(a[i])
    i+=1
print(a.find(b))

def test(str):
    print(str)
    return 6
t=test("ceshi")
print(t)


for letter in "1231321dsfga":
    if letter=='d':
        pass
        print("pass section")
    print(letter);
print("Good bye!")


import time

def sum1():
    sum=1+2;
    print(sum)
sum1()


def timeit(func):
     start=time.clock()
     func()
     end=time.clock()
     print(end-start)


timeit(sum1)

def timeit1(func):
    def test():
        start=time.clock()
        func()
        end=time.clock()
        print(end-start)
    return test

sum1=timeit1(sum1)
sum1()

#语法糖

@timeit1
def sum2():
    sum=1+2;
    print(sum)
sum2()

import os

f=open('aaaaa.txt','r') #默认打开模式就为r
for x in f:
    pass
    data=f.read()
    print(data)
f.close()


