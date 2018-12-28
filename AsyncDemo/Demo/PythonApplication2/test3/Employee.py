class Employee(object):
    """description of class"""
    empCount = 0
    def __init__(self, name, salary):
        self.name=name
        self.salary=salary
        Employee.empCount+=1
    def displaycount(self):
        print ("total count is %d",Employee.empCount)
    def displayEmployee(self):
      print ("Name : ", self.name,  ", Salary: ", self.salary)


