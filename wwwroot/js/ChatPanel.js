﻿function scrollToBottom() {
    const container = document.getElementById("chatMessages");
    if (container) {
        container.scrollTop = container.scrollHeight;
    }
}