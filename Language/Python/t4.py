class NumMatrix(object):
    def __init__(self, matrix):
        """
        initialize your data structure here.
        :type matrix: List[List[int]]
        """
        row = len(matrix)
        if row == 0:
            return
        col = len(matrix[0])
        if col == 0:
            return
        self.sum = []
        s = 0
        for i in range(row):
            s += matrix[i][0]
            self.sum.append([])
            self.sum[i].append(s)
        s = matrix[0][0]
        for j in range(1, col):
            s += matrix[0][j]
            self.sum[0].append(s)
        for i in range(1, row):
            for j in range(1, col):
                self.sum[i].append(self.sum[i-1][j] + self.sum[i][j-1] - self.sum[i-1][j-1])