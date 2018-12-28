
import socket
client = socket.socket()
client.connect(('172.16.7.58',8888))
while True:
    cmd = input(">>:").strip()
    if len(cmd) == 0:continue
    client.send(cmd.encode('utf-8'))
    data = client.recv(10240)
    print("从服务器接受到的数据:",data.decode())

client.close()