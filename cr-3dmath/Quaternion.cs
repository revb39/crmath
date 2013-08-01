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

class Quaternion
{
    public float x, y, z, w;

    //constructors
    public Quaternion()
    {
        this.x = 0;
        this.y = 0;
        this.z = 0;
        this.w = 1;
    }
    public Quaternion(float[] arr)
    {
        this.x = arr[0];
        this.y = arr[1];
        this.z = arr[2];
        this.w = arr[3];
    }
    public Quaternion(Quaternion quat)
    {
        this.x = quat.x;
        this.y = quat.y;
        this.z = quat.z;
        this.w = quat.w;
    }
    public Quaternion(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    //unary operators using quaternions
    public static Quaternion operator +(Quaternion a, Quaternion b)
    {
        return new Quaternion(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
    }
    public static Quaternion operator -(Quaternion a, Quaternion b)
    {
        return new Quaternion(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
    }
    public static Quaternion operator *(Quaternion a, Quaternion b)
    {
        Quaternion o = new Quaternion();
        o.w = (a.w * b.w) - (a.x * b.x) - (a.y * b.y) - (a.z * b.z);
        o.x = (a.w * b.x) + (a.x * b.w) + (a.y * b.z) - (a.z * b.y);
        o.y = (a.w * b.y) - (a.x * b.z) + (a.y * b.w) + (a.z * b.x);
        o.z = (a.w * b.z) + (a.x * b.y) - (a.y * b.x) + (a.z * b.w);
        return o;
    }

    //unary operators using constants
    public static Quaternion operator +(Quaternion a, float b)
    {
        Quaternion o = new Quaternion();
        o.x = a.x + b;
        o.y = a.y + b;
        o.z = a.z + b;
        o.w = a.w + b;
        return o;
    }
    public static Quaternion operator -(Quaternion a, float b)
    {
        Quaternion o = new Quaternion();
        o.x = a.x - b;
        o.y = a.y - b;
        o.z = a.z - b;
        o.w = a.w - b;
        return o;
    }
    public static Quaternion operator *(Quaternion a, float b)
    {
        Quaternion o = new Quaternion();
        o.x = a.x * b;
        o.y = a.y * b;
        o.z = a.z * b;
        o.w = a.w * b;
        return o;
    }
    public static Quaternion operator /(Quaternion a, float b)
    {
        Quaternion o = new Quaternion();
        o.x = a.x / b;
        o.y = a.y / b;
        o.z = a.z / b;
        o.w = a.w / b;
        return o;
    }

    //comparison operators
    public static bool operator ==(Quaternion a, Quaternion b)
    {
        return a.Equals(b);
    }
    public static bool operator !=(Quaternion a, Quaternion b)
    {
        return !a.Equals(b);
    }

    //standard .NET type methods
    public void Copy(Quaternion obj)
    {
        obj.x = this.x;
        obj.y = this.y;
        obj.z = this.z;
        obj.w = this.w;
    }
    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(Quaternion))
            return false;
        Quaternion q = obj as Quaternion;
        return (this.x == q.x) && (this.y == q.y) && (this.z == q.z) && (this.w == q.w);
    }
    public override int GetHashCode()
    {
        return this.x.GetHashCode() + this.y.GetHashCode() + this.z.GetHashCode() + this.w.GetHashCode();
    }
    public float[] ToArray()
    {
        return new float[4] { this.x, this.y, this.z, this.w };
    }
    public string ToString(string format = "0.########")
    {
        return "(" + this.x.ToString(format) + "," + this.y.ToString(format) + "," + this.z.ToString(format) + "," + this.w.ToString(format) + ")";
    }

    //type-specific methods
    public Quaternion Inverse()
    {
        float n = (this.x * this.x) + (this.y * this.y) + (this.z * this.z) + (this.w * this.w);
        return new Quaternion(-this.x/n, -this.y/n, -this.z/n, this.w/n);
    }
    public float Length()
    {
        return (float)Math.Sqrt((this.w * this.w) + (this.x * this.x) + (this.y * this.y) + (this.z * this.z));
    }
    public Quaternion Normalize()
    {
        Quaternion o = new Quaternion(this);
        float mag = this.Length();
        o.w /= mag;
        o.x /= mag;
        o.y /= mag;
        o.z /= mag;

        return o;
    }
    public Quaternion Slerp(Quaternion q, float t)
    {
        float dot = (this.w * q.w) + (this.x * q.x) + (this.y * q.y) + (this.z * q.z);
        if (dot > 0.9995f)
            return this + (q - this) * t;
        if (dot < -1)
            dot = -1;
        if (dot > 1)
            dot = 1;
        float theta0 = (float)Math.Acos(dot);
        float theta = theta0 * t;

        Quaternion o = Quaternion.Normalize(q - this * dot);

        return this * (float)Math.Cos(theta) + o * (float)Math.Sin(theta);
    }

    //static type-specific methods
    public static Quaternion Identity()
    {
        return new Quaternion(0, 0, 0, 1);
    }
    public static Quaternion Invert(Quaternion v)
    {
        return v.Inverse();
    }
    public static float Length(Quaternion q)
    {
        return (float)Math.Sqrt((q.w * q.w) + (q.x * q.x) + (q.y * q.y) + (q.z * q.z));
    }
    public static Quaternion Normalize(Quaternion q)
    {
        Quaternion o = new Quaternion(q);
        float mag = q.Length();
        o /= mag;
        o /= mag;
        o /= mag;
        o /= mag;
        return o;
    }
    public static Quaternion Slerp(Quaternion a, Quaternion b, float t)
    {
        return a.Slerp(b, t);
    }
    public static Quaternion RotationAxis(Vector3 axis, float angle)
    {
        Quaternion o = new Quaternion(0, 0, 0, (float)Math.Cos(angle / 2.0f));
        float s = (float)Math.Sin(angle / 2.0f) / (float)Math.Sqrt(axis.x * axis.x + axis.y * axis.y + axis.z * axis.z);
        o.x = axis.x * s;
        o.y = axis.y * s;
        o.z = axis.z * s;
        return o;
    }
    public static Quaternion RotationMatrix(Matrix4x4 m)
    {
        Quaternion o = new Quaternion();
        float t = m[0, 0] + m[1, 1] + m[2, 2];
        float s = 1;
        if (t > 0)
        {
            s = (float)Math.Sqrt(t+1.0f)*2.0f;
            o.w = 0.25f * s;
            o.x = (m[2, 1] - m[1, 2]) / s;
            o.y = (m[0, 2] - m[2, 0]) / s;
            o.z = (m[1, 0] - m[0, 1]) / s;
        }
        else if ((m[0, 0] > m[1, 1]) && (m[0, 0] > m[2, 2]))
        {
            s = (float)Math.Sqrt(1.0f + m[0, 0] - m[1, 1] - m[2, 2]) * 2.0f;
            o.w = (m[2, 1] - m[1, 2]) / s;
            o.x = 0.25f * s;
            o.y = (m[0, 1] + m[1, 0]) / s;
            o.z = (m[0, 2] + m[2, 0]) / s;
        }
        else if (m[1, 1] > m[2, 2])
        {
            s = (float)Math.Sqrt(1.0f + m[1, 1] - m[0, 0] - m[2, 2]) * 2.0f;
            o.w = (m[0, 2] - m[2, 0]) / s;
            o.x = (m[0, 1] + m[1, 0]) / s;
            o.y = 0.25f * s;
            o.z = (m[1, 2] + m[2, 1]) / s;
        }
        else
        {
            s = (float)Math.Sqrt(1.0f + m[2, 2] - m[0, 0] - m[1, 1]) * 2.0f;
            o.w = (m[1, 0] - m[0, 1]) / s;
            o.x = (m[0, 2] + m[2, 0]) / s;
            o.y = (m[1, 2] + m[2, 1]) / s;
            o.z = 0.25f * s;
        }
        return o;
    }
    public static Quaternion RotationYawPitchRoll(float yaw, float pitch, float roll)
    {
        Quaternion o = new Quaternion();
        o.w = (float)Math.Cos(roll / 2) * (float)Math.Cos(pitch / 2) * (float)Math.Cos(yaw / 2) + (float)Math.Sin(roll / 2) * (float)Math.Sin(pitch / 2) * (float)Math.Sin(yaw / 2);
        o.z = (float)Math.Sin(roll / 2) * (float)Math.Cos(pitch / 2) * (float)Math.Cos(yaw / 2) - (float)Math.Cos(roll / 2) * (float)Math.Sin(pitch / 2) * (float)Math.Sin(yaw / 2);
        o.x = (float)Math.Cos(roll / 2) * (float)Math.Sin(pitch / 2) * (float)Math.Cos(yaw / 2) + (float)Math.Sin(roll / 2) * (float)Math.Cos(pitch / 2) * (float)Math.Sin(yaw / 2);
        o.y = (float)Math.Cos(roll / 2) * (float)Math.Cos(pitch / 2) * (float)Math.Sin(yaw / 2) - (float)Math.Sin(roll / 2) * (float)Math.Sin(pitch / 2) * (float)Math.Cos(yaw / 2);
        return o;
    }
    
}
