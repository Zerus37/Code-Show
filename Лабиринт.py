from turtle import *
from time import sleep
from random import *

cell_size = 40
labirint_size = 15

turtle = Turtle()
turtle.pensize(3)
turtle.speed(0)

half_labirint = labirint_size*cell_size/2

class cell():
    def __init__(self, x,y):
        self.x = x
        self.x_pixel = x*cell_size - half_labirint
        self.y = y
        self.y_pixel = y*cell_size - half_labirint
        self.down = True
        self.left = True
        self.visited = False

    def drow(self):
        turtle.penup()
        turtle.goto(self.x_pixel+cell_size,self.y_pixel)
        if(self.down):
            turtle.pendown()
        turtle.goto(self.x_pixel,self.y_pixel)
        if(self.left):
            turtle.pendown()
            turtle.goto(self.x_pixel,self.y_pixel+cell_size)

            
cells = list()
for x in range(labirint_size):
    cells_row = list()
    for y in range(labirint_size):
        cells_row.append(cell(x,y))
        if y == labirint_size - 1:
            cells_row[y].left = False
        if x == labirint_size - 1:
            cells_row[y].down = False
    cells.append(cells_row)

current_cell = cells[0][0]
current_cell.visited = True
back_track_list = [current_cell]

def RemoveWall(current,chosen):
    if current.x == chosen.x:
        if current.y > chosen.y:
            current.down = False
        else:
            chosen.down = False
    else:
        if current.x > chosen.x:
            current.left = False
        else:
            chosen.left = False

while len(back_track_list) != 0:
    unvisited = list()

    x = current_cell.x
    y = current_cell.y

    if(x > 0):
        if cells[x - 1][y].visited == False:
            unvisited.append(cells[x - 1][y])
    if(y > 0):
        if cells[x][y - 1].visited == False:
            unvisited.append(cells[x][y - 1])
    if(x < labirint_size - 2):
        if cells[x + 1][y].visited == False:
            unvisited.append(cells[x + 1][y])
    if(y < labirint_size - 2):
        if cells[x][y+1].visited == False:
            unvisited.append(cells[x][y+1])

    if len(unvisited) > 0:
        chosen = unvisited[randint(0,len(unvisited))-1]
        RemoveWall(current_cell,chosen)
        chosen.visited = True
        current_cell = chosen
        back_track_list.append(chosen)
    else:
        back_track_list.pop(len(back_track_list)-1)
        if len(back_track_list) > 0:
            current_cell = back_track_list[len(back_track_list)-1]

cells[labirint_size-1][randint(0,labirint_size-2)].left = False

for i in range(labirint_size//7):
    cells[randint(1,labirint_size-2)][randint(1,labirint_size-2)].left = False
    cells[randint(1,labirint_size-2)][randint(1,labirint_size-2)].down = False

for row in cells:
    for cel in row:
        cel.drow()


def try_goto_cell(x,y):
    turtle.goto(x*cell_size+cell_size/2 - half_labirint,y*cell_size+cell_size/2 - half_labirint)

turtle.penup()
turtle.shape('circle')
turtle.color('green')
turtle.pensize(5)
turtle.speed(3)

turtle.x = 0
turtle.y = randint(0,labirint_size-2)

try_goto_cell(turtle.x,turtle.y)
turtle.pendown()

def checkWay(start_x,start_y,tartget_x,tartget_y):
    step = 1
    
    if not (start_x == tartget_x or start_y == tartget_y):
        return False

    if start_y == tartget_y:
        if(start_x>tartget_x):
            step = -1
            start_x += 1
            tartget_x += 1
        for i in range(start_x+step,tartget_x+step, step):
            if cells[i][start_y].left:
                return False
    elif start_x == tartget_x:
        if(start_y>tartget_y):
            step = -1
            start_y += 1
            tartget_y += 1
        for i in range(start_y+step,tartget_y+step,step):
            if cells[start_x][i].down:
                return False
    return True

def btnclick(x, y):
    tartget_x = int((x+half_labirint)//cell_size)
    tartget_y = int((y+half_labirint)//cell_size)

    if checkWay(turtle.x,turtle.y,tartget_x,tartget_y):
        turtle.goto(x,y)
        turtle.x = tartget_x
        turtle.y = tartget_y


listen()
onscreenclick(btnclick, 1)
done()
