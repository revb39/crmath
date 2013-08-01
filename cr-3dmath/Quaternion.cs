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
/// A quaternion containing X,Y,Z,W components
/// </summary>
class Quaternion
{
    public float x, y, z, w;

    //constructors
    /// <summary>
    /// Constructs a new identity Quaternion
    /// </summary>
    public Quaternion()
    {
        this.x = 0;
        this.y = 0;
        this.z = 0;
        this.w = 1;
    }
    /// <summary>
    /// Constructs a new Quaternion, copying the data from a float array
    /// </summary>
    /// <param name="arr">the float array to copy the data from</param>
    public Quaternion(float[] arr)
    {
        this.x = arr[0];
        this.y = arr[1];
        this.z = arr[2];
        this.w = arr[3];
    }
    /// <summary>
    /// Constructs a new Quaternion, copying data from another Quaternion
    /// </summary>
    /// <param name="quat">the quaternion to copy the data from</param>
    public Quaternion(Quaternion quat)
    {
        this.x = quat.x;
        this.y = quat.y;
        this.z = quat.z;
        this.w = quat.w;
    }
    /// <summary>
    /// Constructs a new Quaternion using the specified values
    /// </summary>
    /// <param name="x">the x-value of the quaternion</param>
    /// <param name="y">the y-value of the quaternion</param>
    /// <param name="z">the z-value of the quaternion</param>
    /// <param name="w">the w-value of the quaternion</param>
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
    /// <summary>
    /// Copies the Quaternion to another Quaternion
    /// </summary>
    /// <param name="obj">the quaternion to copy to</param>
    public void Copy(Quaternion obj)
    {
        obj.x = this.x;
        obj.y = this.y;
        obj.z = this.z;
        obj.w = this.w;
    }
    /// <summary>
    /// Determines if this Quaternion is equivalent to another object
    /// </summary>
    /// <param name="obj">the object to compare to</param>
    /// <returns>true: the objects are of the type Quaternion and are equivalent, false: the objects are not of the type Quaternion or are not equivalent</returns>
    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(Quaternion))
            return false;
        Quaternion q = obj as Quaternion;
        return (this.x == q.x) && (this.y == q.y) && (this.z == q.z) && (this.w == q.w);
    }
    /// <summary>
    /// Serves as a hash function for the Quaternion type
    /// </summary>
    /// <returns>a hash code for the current object</returns>
    public override int GetHashCode()
    {
        return this.x.GetHashCode() + this.y.GetHashCode() + this.z.GetHashCode() + this.w.GetHashCode();
    }
    /// <summary>
    /// Converts this Quaternion to a float array
    /// </summary>
    /// <returns>a float array containing the quaternion data</returns>
    public float[] ToArray()
    {
        return new float[4] { this.x, this.y, this.z, this.w };
    }
    /// <summary>
    /// Converts the Quaternion into it's string representation
    /// </summary>
    /// <param name="format">a numberic string format</param>
    /// <returns>the string representation of this quaternion</returns>
    public string ToString(string format = "0.########")
    {
        return "(" + this.x.ToString(format) + "," + this.y.ToString(format) + "," + this.z.ToString(format) + "," + this.w.ToString(format) + ")";
    }

    //type-specific methods
    /// <summary>
    /// Computes the inverse of this Quaternion
    /// </summary>
    /// <returns>the inverse of this quaternion</returns>
    public Quaternion Inverse()
    {
        float n = (this.x * this.x) + (this.y * this.y) + (this.z * this.z) + (this.w * this.w);
        return new Quaternion(-this.x/n, -this.y/n, -this.z/n, this.w/n);
    }
    /// <summary>
    /// Computes the length of this Quaternion
    /// </summary>
    /// <returns>the length of this quaternion</returns>
    public float Length()
    {
        return (float)Math.Sqrt((this.w * this.w) + (this.x * this.x) + (this.y * this.y) + (this.z * this.z));
    }
    /// <summary>
    /// Computes a unit length Quaternion
    /// </summary>
    /// <returns>the normalized quaternion</returns>
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
    /// <summary>
    /// Performs spherical linear interpolation between this Quaternion and another Quaternion
    /// </summary>
    /// <param name="q">the quaternion to interpolate to</param>
    /// <param name="t">the interpolation parameter</param>
    /// <returns>a quaternion interpolated between this quaternion and a specified quaternion</returns>
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
    /// <summary>
    /// Builds a new Identity Quaternion
    /// </summary>
    /// <returns>a new Identity quaternion</returns>
    public static Quaternion Identity()
    {
        return new Quaternion(0, 0, 0, 1);
    }
    /// <summary>
    /// Inverts a specified Quaternion
    /// </summary>
    /// <param name="q">the quaternion to invert</param>
    /// <returns>the inverse of the specified quaternion</returns>
    public static Quaternion Invert(Quaternion q)
    {
        return q.Inverse();
    }
    /// <summary>
    /// Computes the length of a specified Quaternion
    /// </summary>
    /// <param name="q">the quaternion to compute</param>
    /// <returns>the length of the specified quaternion</returns>
    public static float Length(Quaternion q)
    {
        return (float)Math.Sqrt((q.w * q.w) + (q.x * q.x) + (q.y * q.y) + (q.z * q.z));
    }
    /// <summary>
    /// Computes a unit length Quaternion
    /// </summary>
    /// <param name="q">the quaternion to compute from</param>
    /// <returns>the normalized quaternion representation of the specified quaternion</returns>
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
    /// <summary>
    /// Performs spherical linear interpolation between a specified Quaternion and another specified Quaternion
    /// </summary>
    /// <param name="a">the quaternion to interpolate from</param>
    /// <param name="b">the quaternion to interpolate to</param>
    /// <param name="t">the interpolation parameter</param>
    /// <returns>a quaternion interpolated between two specified quaternion</returns>
    public static Quaternion Slerp(Quaternion a, Quaternion b, float t)
    {
        return a.Slerp(b, t);
    }
    /// <summary>
    /// Rotates a Quaternion about an arbitrary axis
    /// </summary>
    /// <param name="axis">the axis about which to rotate the quaternion</param>
    /// <param name="angle">angle of rotation, in radians</param>
    /// <returns>a quaternion rotated about an arbitrary axis</returns>
    public static Quaternion RotationAxis(Vector3 axis, float angle)
    {
        Quaternion o = new Quaternion(0, 0, 0, (float)Math.Cos(angle / 2.0f));
        float s = (float)Math.Sin(angle / 2.0f) / (float)Math.Sqrt(axis.x * axis.x + axis.y * axis.y + axis.z * axis.z);
        o.x = axis.x * s;
        o.y = axis.y * s;
        o.z = axis.z * s;
        return o;
    }
    /// <summary>
    /// Builds a Quaternion from a rotation matrix
    /// </summary>
    /// <param name="m">the source matrix</param>
    /// <returns>a new quaternion built from a rotation matrix</returns>
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
    /// <summary>
    /// Builds a Quaternion with the given yaw, pitch, and roll
    /// </summary>
    /// <param name="yaw">yaw around the y-axis</param>
    /// <param name="pitch">pitch around the x-axis</param>
    /// <param name="roll">roll around the z-axis</param>
    /// <returns>a quaternion built from the given yaw, pitch, and roll</returns>
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
