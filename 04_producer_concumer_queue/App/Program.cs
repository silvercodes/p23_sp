using App.Jobs;
using PCQ;

PCQueue queue = new PCQueue(10);

for (int i = 0; i < 100; ++i)
    queue.EnqueueJob(new SendEmailJob() { Email = $"email_{i}@mail.com" });





