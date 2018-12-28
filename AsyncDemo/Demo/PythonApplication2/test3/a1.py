def test1():
    print("this is test1 method.")

def fo():
    try:
        fh=open("aaa",'w')
        fh.write("这是一个测试文件，用于测试异常!!")  
    except Exception:
        print("Error: 没有找到文件或读取文件失败")
    else:
        print("内容写入文件成功")
        fh.close()