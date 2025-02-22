﻿/*
  Copyright (C) 2011 Jeroen Frijters

  This software is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this software.

  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this software must not be misrepresented; you must not
     claim that you wrote the original software. If you use this software
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original software.
  3. This notice may not be removed or altered from any source distribution.

  Jeroen Frijters
  jeroen@frijters.net
  
*/

using System;

namespace IKVM.Java.Externs.sun.nio.ch
{

    static class ServerSocketChannelImpl
    {

        public static int accept0(object self, global::java.io.FileDescriptor ssfd, global::java.io.FileDescriptor newfd, object isaa)
        {
#if FIRST_PASS
            throw new NotSupportedException();
#else
            try
            {
                System.Net.Sockets.Socket netSocket = ssfd.getSocket();
                if (netSocket.Blocking || netSocket.Poll(0, System.Net.Sockets.SelectMode.SelectRead))
                {
                    System.Net.Sockets.Socket accsock = netSocket.Accept();
                    newfd.setSocket(accsock);
                    System.Net.IPEndPoint ep = (System.Net.IPEndPoint)accsock.RemoteEndPoint;
                    ((global::java.net.InetSocketAddress[])isaa)[0] = new global::java.net.InetSocketAddress(global::java.net.SocketUtil.getInetAddressFromIPEndPoint(ep), ep.Port);
                    return 1;
                }
                else
                {
                    return global::sun.nio.ch.IOStatus.UNAVAILABLE;
                }
            }
            catch (System.Net.Sockets.SocketException x)
            {
                throw global::java.net.SocketUtil.convertSocketExceptionToIOException(x);
            }
            catch (System.ObjectDisposedException)
            {
                throw new global::java.net.SocketException("Socket is closed");
            }
#endif
        }

        public static void initIDs()
        {

        }

    }

}
