﻿using System;

namespace ManagedWimgapi {
    /// <summary>
    /// Specifies the access to open the image with
    /// </summary>
    [Flags]
    public enum WimAccess : uint {
        /// <summary>
        /// Specifies query-only access to the image file, allowing reading of image metadata, but not image contents.
        /// </summary>
        QueryOnly = 0,
        /// <summary>
        /// Specifies read-only access to the image file. Enables images to be applied from the file.
        /// Combine with <see cref="Write"/> for read/write (append) access.
        /// </summary>
        Read = 0x80000000,
        /// <summary>
        /// Specifies write access to the image file. Enables images to be captured to the file.
        /// Includes <see cref="Read"/> access to enable apply and append operations with existing images.
        /// </summary>
        Write = 0x40000000,
        /// <summary>
        /// Specifies mount access to the image file.
        /// Enables images to be mounted with WIMMountImageHandle.
        /// </summary>
        // TODO: replace the reference to WIMMountImageHandle
        Mount = 0x20000000,
        /// <summary>
        /// Convenience enumeration for read, write, and mount access.
        /// </summary>
        All = Read | Write | Mount
    }

    /// <summary>
    /// Specifies which action to take on files that exist, and which action to take when files do not exist.
    /// </summary>
    public enum WimMode : uint {
        /// <summary>
        /// Makes a new image file. Fails if the specified file already exists.
        /// </summary>
        CreateNew = 1,
        /// <summary>
        /// Makes a new image file. Overwrites if the file already exists.
        /// </summary>
        CreateAlways = 2,
        /// <summary>
        /// Opens the image file. Fails if the file does not exist.
        /// </summary>
        OpenExisting = 3,
        /// <summary>
        /// Opens the image file if it exists. If the file does not exist and the caller requests <see cref="WimAccess.Write"/> access, the function makes the file.
        /// </summary>
        OpenAlways = 4
    }

    /// <summary>
    /// Specifies the options used when creating a WIM file.
    /// </summary>
    [Flags]
    public enum WimCreationOptions : uint {
        /// <summary>
        /// Do not use any special options.
        /// </summary>
        None = 0,
        /// <summary>
        /// Generates data integrity information for new files. Verifies and updates existing files.
        /// </summary>
        Verify = NativeMethods.WIM_FLAG_VERIFY,
        /// <summary>
        /// Opens the .wim file in a mode that enables simultaneous reading and writing.
        /// </summary>
        ShareWrite = NativeMethods.WIM_FLAG_SHARE_WRITE
    }

    /// <summary>
    /// Specifies the compression mode on a WIM.
    /// </summary>
    public enum WimCompressionType : uint {
        /// <summary>
        /// No compression.
        /// </summary>
        None = 0,
        /// <summary>
        /// Xpress compression.
        /// </summary>
        Xpress = 1,
        /// <summary>
        /// Lzx compression.
        /// </summary>
        Lzx = 2,
        /// <summary>
        /// Lzms compression.
        /// </summary>
        Lzms = 3
    }
}
