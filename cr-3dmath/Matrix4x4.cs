/*
    CRMath Copyright (c) 2013 Justin Byers


    This file is part of CRMath.

    CRMath is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    CRMath is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with CRMath.  If not, see <http://www.gnu.org/licenses/>.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Represents a Matrix of order 4x4
/// </summary>
class Matrix4x4
{
    //constructors
    /// <summary>
    /// Constructs a new matrix filled with zeros
    /// </summary>
    public Matrix4x4()
    {
        _ij = new float[4, 4];
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                _ij[r, c] = 0.0f;
            }
        }
    }
    /// <summary>
    /// Constructs a new matrix, copying the data from a specified multidimensional float array
    /// </summary>
    /// <param name="pInitData">the multidimensional float array to copy data from</param>
    public Matrix4x4(float[,] pInitData)
    {
        _ij = new float[4, 4];
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                _ij[r, c] = pInitData[r,c];
            }
        }
    }
    /// <summary>
    /// Constructs a new matrix, copying the data from another matrix
    /// </summary>
    /// <param name="pInitMatrix">the matrix to copy data from</param>
    public Matrix4x4(Matrix4x4 pInitMatrix)
    {
        _ij = new float[4, 4];
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                _ij[r, c] = pInitMatrix[r, c];
            }
        }
    }
    /// <summary>
    /// Constructs a new matrix using the specified elements
    /// </summary>
    public Matrix4x4(float _11, float _12, float _13, float _14,
                        float _21, float _22, float _23, float _24,
                        float _31, float _32, float _33, float _34,
                        float _41, float _42, float _43, float _44)
    {
        _ij = new float[4, 4];
        _ij[0, 0] = _11; _ij[0, 1] = _12; _ij[0, 2] = _13; _ij[0, 3] = _14;
        _ij[1, 0] = _21; _ij[1, 1] = _22; _ij[1, 2] = _23; _ij[1, 3] = _24;
        _ij[2, 0] = _31; _ij[2, 1] = _32; _ij[2, 2] = _33; _ij[2, 3] = _34;
        _ij[3, 0] = _41; _ij[3, 1] = _42; _ij[3, 2] = _43; _ij[3, 3] = _44;
    }

    //access grant
    public float this[int row, int col]
    {
        get { return _ij[row,col]; }
        set { _ij[row,col] = value; }
    }

    //unary operators using matrices
    public static Matrix4x4 operator +(Matrix4x4 a, Matrix4x4 b)
    {
        Matrix4x4 o = new Matrix4x4();
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                o[r, c] = a[r, c] + b[r, c];
            }
        }
        return o;
    }
    public static Matrix4x4 operator -(Matrix4x4 a, Matrix4x4 b)
    {
        Matrix4x4 o = new Matrix4x4();
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                o[r, c] = a[r, c] - b[r, c];
            }
        }
        return o;
    }
    public static Matrix4x4 operator *(Matrix4x4 a, Matrix4x4 b)
    {
        Matrix4x4 o = new Matrix4x4();
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                for (int i = 0; i < 4; i++)
                {
                    o[r,c] += a[r, i] * b[i, c];
                }
            }
        }
        return o;
    }

    //unary operators using constants
    public static Matrix4x4 operator +(Matrix4x4 a, float b)
    {
        Matrix4x4 o = new Matrix4x4();
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                o[r, c] = a[r, c] + b;
            }
        }
        return o;
    }
    public static Matrix4x4 operator -(Matrix4x4 a, float b)
    {
        Matrix4x4 o = new Matrix4x4();
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                o[r, c] = a[r, c] - b;
            }
        }
        return o;
    }
    public static Matrix4x4 operator *(Matrix4x4 a, float b)
    {
        Matrix4x4 o = new Matrix4x4();
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                o[r, c] = a[r,c]*b;
            }
        }
        return o;
    }
    public static Matrix4x4 operator /(Matrix4x4 a, float b)
    {
        Matrix4x4 o = new Matrix4x4();
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                o[r, c] /= b;
            }
        }
        return o;
    }

    //comparison operators
    public static bool operator ==(Matrix4x4 a, Matrix4x4 b)
    {
        return a.Equals(b);
    }
    public static bool operator !=(Matrix4x4 a, Matrix4x4 b)
    {
        return !a.Equals(b);
    }

    //standard .NET type methods
    /// <summary>
    /// Copies the matrix to another Matrix4x4
    /// </summary>
    /// <param name="obj">Matrix4x4 to copy to</param>
    public void Copy(Matrix4x4 obj)
    {
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                obj[r, c] = _ij[r, c];
            }
        }
    }
    /// <summary>
    /// Determines if this matrix is equivalent to another matrix
    /// </summary>
    /// <param name="obj">the matrix to compare to</param>
    /// <returns>true: the matrices are equivalent, false: the matrixes are not equivalent</returns>
    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(Matrix4x4))
            return false;
        Matrix4x4 m = obj as Matrix4x4;
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                if (_ij[r, c] != m[r, c])
                {
                    return false;
                }
            }
        }
        return true;
    }
    /// <summary>
    /// Serves as a hash function for the Matrix4x4 type
    /// </summary>
    /// <returns>a hash code for the current object</returns>
    public override int GetHashCode()
    {
        int hash = 0;
        for (int r=0;r<4;r++)
        {
            for (int c = 0; c < 4; c++)
            {
                hash += _ij[r, c].GetHashCode();
            }
        }
        return hash;
    }
    /// <summary>
    /// Converts this matrix to a multidimensional float array
    /// </summary>
    /// <returns>a multidimensional float array containing the matrix data</returns>
    public float[,] ToArray()
    {
        float[,] o = new float[4, 4];
        _ij.CopyTo(o, 0);
        return o;
    }
    /// <summary>
    /// Converts the matrix into its string representation
    /// </summary>
    /// <param name="format">A numeric string format</param>
    /// <returns>the string representation of this matrix</returns>
    public string ToString(string format="F")
    {
        string row = "";
        for (int r = 0; r < 4; r++)
        {
            row += "[";
            for (int c = 0; c < 4; c++)
            {
                row += _ij[r, c].ToString(format);
                if (c != 3)
                    row += ",";
            }
            row += "]\n";
        }
        return row;
    }

    //type-specific methods
    /// <summary>
    /// Calculates the adjoint matrix
    /// </summary>
    /// <returns>the adjoint matrix</returns>
    public Matrix4x4 Adjoint()
    {
        Matrix4x4 adj = new Matrix4x4();
        for (int r=0;r<4;r++)
        {
            for (int c = 0; c < 4; c++)
            {
                adj[r, c] = (float)Math.Pow(-1, (r + 1) + (c + 1)) * Minor(r + 1, c + 1);
            }
        }
        return adj.Transpose();
    }
    /// <summary>
    /// Calculates the determinant of this matrix
    /// </summary>
    /// <param name="row">the row to use to perform the calculation. 0 by default</param>
    /// <returns>the determinant of this matrix</returns>
    public float Determinant(int row=0)
    {
        float d = 0;
        for (int c = 0; c < 4; c++)
        {
            float cof = (float)Math.Pow(-1, (row + 1) + (c + 1))*Minor(row + 1, c + 1);
            d += _ij[row, c] * cof;
        }
        return d;
    }
    /// <summary>
    /// Calculates the inverse of this matrix
    /// </summary>
    /// <returns>the inverse of this matrix</returns>
    public Matrix4x4 Inverse()
    {
        float d = this.Determinant();
        if (d == 0)
            throw new Exception("Cannot calculate inverse of singular matrix!");
        return this.Adjoint() * (1.0f/d);
    }
    /// <summary>
    /// Calculates the minor at the specified row and column
    /// </summary>
    /// <param name="row">the row of the element to calculate</param>
    /// <param name="col">the column of the element to calculate</param>
    /// <returns>the minor at (row)x(col)</returns>
    public float Minor(int row, int col)
    {
        float[,] m = new float[3, 3]; //the matrix that the minor calculation will be made on
        int pr = 0; //these will be used to skip the row & col that are removed for calculation
        int pc = 0; 
        //build the new 3x3 matrix
        for (int r = 0; r < 3; r++)
        {
            if (r == row - 1)
                pr = 1;
            pc = 0;
            for (int c = 0; c < 3; c++)
            {
                if (c == col - 1)
                    pc = 1;

                m[r, c] = _ij[r + pr, c + pc];
            }
        }

        //calculate the determinant
        float A = m[0, 0] * ((m[1, 1] * m[2, 2]) - (m[1, 2] * m[2, 1]));
        float B = m[0, 1] * ((m[1, 0] * m[2, 2]) - (m[1, 2] * m[2, 0]));
        float C = m[0, 2] * ((m[1, 0] * m[2, 1]) - (m[1, 1] * m[2, 0]));

        return A-B+C;
    }
    /// <summary>
    /// Calculates the transpose of this matrix
    /// </summary>
    /// <returns>the transpose of this matrix</returns>
    public Matrix4x4 Transpose()
    {
        Matrix4x4 o = new Matrix4x4();
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                o[r, c] = _ij[c, r];
            }
        }
        return o;
    }

    //static type-specific methods
    /// <summary>
    /// Creates an identity matrix
    /// </summary>
    /// <returns>a new identity matrix</returns>
    public static Matrix4x4 Identity()
    {
        Matrix4x4 o = new Matrix4x4();
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                if (r == c)
                    o[r, c] = 1.0f;
                else
                    o[r, c] = 0.0f;
            }
        }

        return o;
    }
    /// <summary>
    /// Builds a left-handed, look-at matrix
    /// </summary>
    /// <param name="eye">Vector3 that defines the eye point (or position of camera)</param>
    /// <param name="at">Vector3 that defiens the camera look-at target</param>
    /// <param name="up">Vector3 that defines the current world's up, usually [0,1,0]</param>
    /// <returns>a new left-handed, look-at matrix</returns>
    public static Matrix4x4 LookAtLH(Vector3 eye, Vector3 at, Vector3 up)
    {
        Vector3 z = Vector3.Normalize(at-eye);
        Vector3 x = Vector3.Normalize(Vector3.Cross(up, z));
        Vector3 y = Vector3.Cross(z, x);

        Matrix4x4 o = new Matrix4x4(x.x, y.x, z.x, 0,
                                    x.y, y.y, z.y, 0,
                                    x.z, y.z, z.z, 0,
                                    -Vector3.Dot(x, eye), -Vector3.Dot(y, eye), -Vector3.Dot(z, eye), 1);
        return o;
    }
    /// <summary>
    /// Builds a right-handed, look-at matrix
    /// </summary>
    /// <param name="eye">Vector3 that defines the eye point (or position of camera)</param>
    /// <param name="at">Vector3 that defiens the camera look-at target</param>
    /// <param name="up">Vector3 that defines the current world's up, usually [0,1,0]</param>
    /// <returns>a new right-handed, look-at matrix</returns>
    public static Matrix4x4 LookAtRH(Vector3 eye, Vector3 at, Vector3 up)
    {
        Vector3 z = Vector3.Normalize(eye-at);
        Vector3 x = Vector3.Normalize(Vector3.Cross(up, z));
        Vector3 y = Vector3.Cross(z, x);

        Matrix4x4 o = new Matrix4x4(x.x, y.x, z.x, 0,
                                    x.y, y.y, z.y, 0,
                                    x.z, y.z, z.z, 0,
                                    Vector3.Dot(x, eye), Vector3.Dot(y, eye), Vector3.Dot(z, eye), 1);
        return o;
    }
    /// <summary>
    /// Builds a left-handed orthographic projection matrix
    /// </summary>
    /// <param name="w">width of the view volume</param>
    /// <param name="h">height of the view volume</param>
    /// <param name="zn">minimum z-value of the view volume which is referred to as z-near</param>
    /// <param name="zf">maximum z-value of the view volume which is referred to as z-far</param>
    /// <returns>a new left-handed orthographic projection matrix</returns>
    public static Matrix4x4 OrthoLH(float w, float h, float zn, float zf)
    {
        Matrix4x4 o = new Matrix4x4(2.0f / w, 0, 0, 0,
                                    0, 2.0f / h, 0, 0,
                                    0, 0, 1.0f / (zf - zn), 0,
                                    0, 0, -zn / (zf - zn), 1);
        return o;
    }
    /// <summary>
    /// Builds a customized, left-handed orthographic projection matrix
    /// </summary>
    /// <param name="l">minimum x-value of view volume</param>
    /// <param name="r">maximum x-value of view volume</param>
    /// <param name="b">minimum y-value of view volume</param>
    /// <param name="t">maximum y-value of view volume</param>
    /// <param name="zn">minimum z-value of the view volume</param>
    /// <param name="zf">maximum z-value of the view volume</param>
    /// <returns>a new customized, left-handed orthographic projection matrix</returns>
    public static Matrix4x4 OrthoOffCenterLH(float l, float r, float b, float t, float zn, float zf)
    {
        Matrix4x4 o = new Matrix4x4(2.0f / (r-l), 0, 0, 0,
                                    0, 2.0f / (t-b), 0, 0,
                                    0, 0, 1.0f / (zf - zn), 0,
                                    (l+r)/(l-r), (t+b)/(b-t), zn / (zn - zf), 1);
        return o;
    }
    /// <summary>
    /// Builds a right-handed orthographic projection matrix
    /// </summary>
    /// <param name="w">width of the view volume</param>
    /// <param name="h">height of the view volume</param>
    /// <param name="zn">minimum z-value of the view volume which is referred to as z-near</param>
    /// <param name="zf">maximum z-value of the view volume which is referred to as z-far</param>
    /// <returns>a new right-handed orthographic projection matrix</returns>
    public static Matrix4x4 OrthoRH(float w, float h, float zn, float zf)
    {
        Matrix4x4 o = new Matrix4x4(2.0f / w, 0, 0, 0,
                                    0, 2.0f / h, 0, 0,
                                    0, 0, 1.0f / (zn - zf), 0,
                                    0, 0, zn / (zn - zf), 1);
        return o;
    }
    /// <summary>
    /// Builds a customized, right-handed orthographic projection matrix
    /// </summary>
    /// <param name="l">minimum x-value of view volume</param>
    /// <param name="r">maximum x-value of view volume</param>
    /// <param name="b">minimum y-value of view volume</param>
    /// <param name="t">maximum y-value of view volume</param>
    /// <param name="zn">minimum z-value of the view volume</param>
    /// <param name="zf">maximum z-value of the view volume</param>
    /// <returns>a new customized, right-handed orthographic projection matrix</returns>
    public static Matrix4x4 OrthoOffCenterRH(float l, float r, float b, float t, float zn, float zf)
    {
        Matrix4x4 o = new Matrix4x4(2.0f / (r - l), 0, 0, 0,
                                    0, 2.0f / (t - b), 0, 0,
                                    0, 0, 1.0f / (zn - zf), 0,
                                    (l + r) / (l - r), (t + b) / (b - t), zn / (zn - zf), 1);
        return o;
    }
    /// <summary>
    /// Builds a left-handed perspective projection matrix based on a field of view
    /// </summary>
    /// <param name="fovy">Field of view in the y direction, in radians</param>
    /// <param name="aspect">Aspect ratio, defined as view space width divided by height</param>
    /// <param name="zn">z-value of the near view-plane</param>
    /// <param name="zf">z-value of the far view-plane</param>
    /// <returns>a new left-handed perspective projection matrix based on a field of view</returns>
    public static Matrix4x4 PerspectiveFovLH(float fovy, float aspect, float zn, float zf)
    {
        float ys = 1.0f/(float)Math.Tan(fovy/2.0f);
        float xs = ys / aspect;

        Matrix4x4 o = new Matrix4x4(xs, 0, 0, 0,
                                    0, ys, 0, 0,
                                    0, 0, zf / (zf - zn), 1,
                                    0, 0, -zn * zf / (zf - zn), 0);
        return o;
    }
    /// <summary>
    /// Builds a right-handed perspective projection matrix based on a field of view
    /// </summary>
    /// <param name="fovy">Field of view in the y direction, in radians</param>
    /// <param name="aspect">Aspect ratio, defined as view space width divided by height</param>
    /// <param name="zn">z-value of the near view-plane</param>
    /// <param name="zf">z-value of the far view-plane</param>
    /// <returns>a new right-handed perspective projection matrix based on a field of view</returns>
    public static Matrix4x4 PerspectiveFovRH(float fovy, float aspect, float zn, float zf)
    {
        float ys = 1.0f / (float)Math.Tan(fovy / 2.0f);
        float xs = ys / aspect;

        Matrix4x4 o = new Matrix4x4(xs, 0, 0, 0,
                                    0, ys, 0, 0,
                                    0, 0, zf / (zn - zf), -1,
                                    0, 0, zn * zf / (zn - zf), 0);
        return o;
    }
    /// <summary>
    /// Builds a left-handed perspective projection matrix
    /// </summary>
    /// <param name="w">width of the view volume at the near view-plane</param>
    /// <param name="h">height of the view volume at the near view-plane</param>
    /// <param name="zn">z-value of the near view-plane</param>
    /// <param name="zf">z-value of the far view-plane</param>
    /// <returns>a new left-handed perspective projection matrix</returns>
    public static Matrix4x4 PerspectiveLH(float w, float h, float zn, float zf)
    {
        Matrix4x4 o = new Matrix4x4(2.0f*zn/w, 0, 0, 0,
                                    0, 2*zn/h, 0, 0,
                                    0, 0, zf/(zf-zn), 1,
                                    0, 0, zn*zf/(zn-zf), 0);
        return o;
    }
    /// <summary>
    /// Builds a customized, left-handed perspective projection matrix
    /// </summary>
    /// <param name="l">minimum x-value of the view volume</param>
    /// <param name="r">maximum x-value of the view volume</param>
    /// <param name="b">minimum y-value of the view volume</param>
    /// <param name="t">maximum y-value of the view volume</param>
    /// <param name="zn">minimum z-value of the view volume</param>
    /// <param name="zf">maximum z-value of the view volume</param>
    /// <returns>a new customized, left-handed perspective projection matrix</returns>
    public static Matrix4x4 PerspectiveOffCenterLH(float l, float r, float b, float t, float zn, float zf)
    {
        Matrix4x4 o = new Matrix4x4(2.0f * zn / (r - l), 0, 0, 0,
                                    0, 2.0f * zn / (t - b), 0, 0,
                                    (l + r) / (l - r), (t + b) / (b - t), zf / (zf - zn), 1,
                                    0, 0, zn * zf / (zn - zf), 0);
        return o;
    }
    /// <summary>
    /// Builds a right-handed perspective projection matrix
    /// </summary>
    /// <param name="w">width of the view volume at the near view-plane</param>
    /// <param name="h">height of the view volume at the near view-plane</param>
    /// <param name="zn">z-value of the near view-plane</param>
    /// <param name="zf">z-value of the far view-plane</param>
    /// <returns>a new right-handed perspective projection matrix</returns>
    public static Matrix4x4 PerspectiveRH(float w, float h, float zn, float zf)
    {
        Matrix4x4 o = new Matrix4x4(2.0f * zn / w, 0, 0, 0,
                                    0, 2 * zn / h, 0, 0,
                                    0, 0, zf / (zn - zf), -1,
                                    0, 0, zn * zf / (zn - zf), 0);
        return o;
    }
    /// <summary>
    /// Builds a customized, right-handed perspective projection matrix
    /// </summary>
    /// <param name="l">minimum x-value of the view volume</param>
    /// <param name="r">maximum x-value of the view volume</param>
    /// <param name="b">minimum y-value of the view volume</param>
    /// <param name="t">maximum y-value of the view volume</param>
    /// <param name="zn">minimum z-value of the view volume</param>
    /// <param name="zf">maximum z-value of the view volume</param>
    /// <returns>a new customized, right-handed perspective projection matrix</returns>
    public static Matrix4x4 PerspectiveOffCenterRH(float l, float r, float b, float t, float zn, float zf)
    {
        Matrix4x4 o = new Matrix4x4(2.0f * zn / (r - l), 0, 0, 0,
                                    0, 2.0f * zn / (t - b), 0, 0,
                                    (l + r) / (r - l), (t + b) / (t - b), zf / (zn - zf), -1,
                                    0, 0, zn * zf / (zn - zf), 0);
        return o;
    }
    /// <summary>
    /// Builds a matrix that rotates around an arbitrary axis
    /// </summary>
    /// <param name="v">Vector3 that represents the arbitrary axis</param>
    /// <param name="angle">angle of rotation in radians</param>
    /// <returns>a new matrix that rotates around an arbitrary axis</returns>
    public static Matrix4x4 RotationAxis(Vector3 v, float angle)
    {
        Matrix4x4 o = Matrix4x4.Identity();
        float c = (float)Math.Cos(angle);
        float s = (float)Math.Sin(angle);
        float t = (1 - (float)Math.Cos(angle));
        float x = v.x;
        float y = v.y;
        float z = v.z;
        o[0, 0] = t * (x * x) + c; o[0, 1] = (t * x * y) + (s * z); o[0, 2] = (t * x * z) - (s * y);
        o[1, 0] = (t * x * y) - (s * z); o[1, 1] = t * (y * y) + c; o[1, 2] = (t * y * z) + (s * x);
        o[2, 0] = (t * x * z) + (s * y); o[2, 1] = (t * y * z) - (s * x); o[2, 2] = t * (z * z) + c;

        return o;
    }
    /// <summary>
    /// Builds a rotation matrix from a quaternion
    /// </summary>
    /// <param name="q">Quaternion that will be sued to build the matrix</param>
    /// <returns>a new rotation matrix from a quaternion</returns>
    public static Matrix4x4 RotationQuaternion(Quaternion q)
    {
        Quaternion qn = Quaternion.Normalize(q);
        float qw = qn.w;
        float qx = qn.x;
        float qy = qn.y;
        float qz = qn.z;
        Matrix4x4 o = new Matrix4x4(1.0f - 2.0f * qy * qy - 2.0f * qz * qz, 2.0f * qx * qy - 2.0f * qz * qw, 2.0f * qx * qz + 2.0f * qy * qw, 0.0f,
                                    2.0f * qx * qy + 2.0f * qz * qw, 1.0f - 2.0f * qx * qx - 2.0f * qz * qz, 2.0f * qy * qz - 2.0f * qx * qw, 0.0f,
                                    2.0f * qx * qz - 2.0f * qy * qw, 2.0f * qy * qz + 2.0f * qx * qw, 1.0f - 2.0f * qx * qx - 2.0f * qy * qy, 0.0f,
                                    0.0f, 0.0f, 0.0f, 1.0f);
        return o;
    }
    /// <summary>
    /// Builds a matrix that rotates around the x-axis
    /// </summary>
    /// <param name="angle">angle of rotation in radians</param>
    /// <returns>a matrix that rotates around the x-axis</returns>
    public static Matrix4x4 RotationX(float angle)
    {
        Matrix4x4 o = Matrix4x4.Identity();
        float c = (float)Math.Cos(angle);
        float s = (float)Math.Sin(angle);
        o[1, 1] = c;
        o[1, 2] = s;
        o[2, 1] = -s;
        o[2, 2] = c;
        return o;
    }
    /// <summary>
    /// Builds a matrix that rotates around the y-axis
    /// </summary>
    /// <param name="angle">angle of rotation in radians</param>
    /// <returns>a matrix that rotates around the y-axis</returns>
    public static Matrix4x4 RotationY(float angle)
    {
        Matrix4x4 o = Matrix4x4.Identity();
        float c = (float)Math.Cos(angle);
        float s = (float)Math.Sin(angle);
        o[0, 0] = c;
        o[0, 2] = -s;
        o[2, 0] = s;
        o[2, 2] = c;
        return o;
    }
    /// <summary>
    /// Builds a matrix that rotates around the z-axis
    /// </summary>
    /// <param name="angle">angle of rotation in radians</param>
    /// <returns>a matrix that rotates around the z-axis</returns>
    public static Matrix4x4 RotationZ(float angle)
    {
        Matrix4x4 o = Matrix4x4.Identity();
        float c = (float)Math.Cos(angle);
        float s = (float)Math.Sin(angle);
        o[0, 0] = c;
        o[0, 1] = s;
        o[1, 0] = -s;
        o[1, 1] = c;
        return o;
    }
    /// <summary>
    /// Builds a matrix with a specified yaw, pitch, and roll
    /// </summary>
    /// <param name="yaw">yaw around the y-axis, in radians</param>
    /// <param name="pitch">pitch around the x-axis, in radians</param>
    /// <param name="roll">roll around the z-axis, in radians</param>
    /// <returns>a matrix with a specified yaw, pitch, and roll</returns>
    public static Matrix4x4 RotationYawPitchRoll(float yaw, float pitch, float roll)
    {
        return Matrix4x4.RotationZ(roll) * Matrix4x4.RotationX(pitch) * Matrix4x4.RotationY(yaw);
    }
    /// <summary>
    /// Builds a matrix using the specified offsets
    /// </summary>
    /// <param name="x">x-coordinate offset</param>
    /// <param name="y">y-coordinate offset</param>
    /// <param name="z">z-coordinate offset</param>
    /// <returns>a new matrix using the specified offsets</returns>
    public static Matrix4x4 Translation(float x, float y, float z)
    {
        Matrix4x4 o = Matrix4x4.Identity();
        o[0, 3] = x;
        o[1, 3] = y;
        o[2, 3] = z;
        return o;
    }

    //the float array that holds the matrix data
    private float[,] _ij;
}